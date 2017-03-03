using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Languages.Antlr4Roslyn.Generator //1:1
{
    using __Hidden_LanguageServiceGenerator_993369021;
    namespace __Hidden_LanguageServiceGenerator_993369021
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


    public class LanguageServiceGenerator //2:1
    {
        private object Instances; //2:1

        public LanguageServiceGenerator() //2:1
        {
            this.Properties = new __Properties();
        }

        public LanguageServiceGenerator(object instances) : this() //2:1
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
                this.LanguageNamespace = null; //7:29
                this.LanguageName = null; //8:24
                this.RoslynCompiler = false; //9:24
                this.GenerateMultipleFiles = false; //10:31
            }
            public string LanguageServiceNamespace { get; set; } //5:2
            public string LanguageClassName { get; set; } //6:2
            public string LanguageNamespace { get; set; } //7:2
            public string LanguageName { get; set; } //8:2
            public bool RoslynCompiler { get; set; } //9:2
            public bool GenerateMultipleFiles { get; set; } //10:2
        }

        public string Generate() //13:1
        {
            StringBuilder __out = new StringBuilder();
            __out.Append("using System;"); //14:1
            __out.AppendLine(false); //14:14
            __out.Append("using System.Collections.Generic;"); //15:1
            __out.AppendLine(false); //15:34
            __out.Append("using System.ComponentModel;"); //16:1
            __out.AppendLine(false); //16:29
            __out.Append("using System.Diagnostics;"); //17:1
            __out.AppendLine(false); //17:26
            __out.Append("using System.IO;"); //18:1
            __out.AppendLine(false); //18:17
            __out.Append("using System.Linq;"); //19:1
            __out.AppendLine(false); //19:19
            __out.Append("using System.Runtime.InteropServices;"); //20:1
            __out.AppendLine(false); //20:38
            __out.Append("using System.Text;"); //21:1
            __out.AppendLine(false); //21:19
            __out.Append("using System.Threading.Tasks;"); //22:1
            __out.AppendLine(false); //22:30
            __out.Append("using Microsoft.VisualStudio.OLE.Interop;"); //23:1
            __out.AppendLine(false); //23:42
            __out.Append("using Microsoft.VisualStudio.Package;"); //24:1
            __out.AppendLine(false); //24:38
            __out.Append("using Microsoft.VisualStudio.Shell.Interop;"); //25:1
            __out.AppendLine(false); //25:44
            __out.Append("using Microsoft.VisualStudio.TextManager.Interop;"); //26:1
            __out.AppendLine(false); //26:50
            __out.Append("using Antlr4.Runtime;"); //27:1
            __out.AppendLine(false); //27:22
            __out.Append("using System.Drawing;"); //28:1
            __out.AppendLine(false); //28:22
            __out.Append("using Microsoft.VisualStudio;"); //29:1
            __out.AppendLine(false); //29:30
            __out.Append("using Microsoft.VisualStudio.Shell;"); //30:1
            __out.AppendLine(false); //30:36
            __out.AppendLine(true); //31:1
            __out.Append("using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;"); //32:1
            __out.AppendLine(false); //32:70
            __out.AppendLine(true); //33:1
            bool __tmp2_outputWritten = false;
            string __tmp3_line = "namespace "; //34:1
            if (!string.IsNullOrEmpty(__tmp3_line))
            {
                __out.Append(__tmp3_line);
                __tmp2_outputWritten = true;
            }
            StringBuilder __tmp4 = new StringBuilder();
            __tmp4.Append(Properties.LanguageServiceNamespace);
            using(StreamReader __tmp4Reader = new StreamReader(this.__ToStream(__tmp4.ToString())))
            {
                bool __tmp4_last = __tmp4Reader.EndOfStream;
                while(!__tmp4_last)
                {
                    string __tmp4_line = __tmp4Reader.ReadLine();
                    __tmp4_last = __tmp4Reader.EndOfStream;
                    if ((__tmp4_last && !string.IsNullOrEmpty(__tmp4_line)) || (!__tmp4_last && __tmp4_line != null))
                    {
                        __out.Append(__tmp4_line);
                        __tmp2_outputWritten = true;
                    }
                    if (!__tmp4_last || __tmp2_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp2_outputWritten)
            {
                __out.AppendLine(false); //34:48
            }
            __out.Append("{"); //35:1
            __out.AppendLine(false); //35:2
            bool __tmp6_outputWritten = false;
            string __tmp7_line = "    public class "; //36:1
            if (!string.IsNullOrEmpty(__tmp7_line))
            {
                __out.Append(__tmp7_line);
                __tmp6_outputWritten = true;
            }
            StringBuilder __tmp8 = new StringBuilder();
            __tmp8.Append(Properties.LanguageClassName);
            using(StreamReader __tmp8Reader = new StreamReader(this.__ToStream(__tmp8.ToString())))
            {
                bool __tmp8_last = __tmp8Reader.EndOfStream;
                while(!__tmp8_last)
                {
                    string __tmp8_line = __tmp8Reader.ReadLine();
                    __tmp8_last = __tmp8Reader.EndOfStream;
                    if ((__tmp8_last && !string.IsNullOrEmpty(__tmp8_line)) || (!__tmp8_last && __tmp8_line != null))
                    {
                        __out.Append(__tmp8_line);
                        __tmp6_outputWritten = true;
                    }
                    if (!__tmp8_last) __out.AppendLine(true);
                }
            }
            string __tmp9_line = "LanguageAuthoringScope : AuthoringScope"; //36:48
            if (!string.IsNullOrEmpty(__tmp9_line))
            {
                __out.Append(__tmp9_line);
                __tmp6_outputWritten = true;
            }
            if (__tmp6_outputWritten) __out.AppendLine(true);
            if (__tmp6_outputWritten)
            {
                __out.AppendLine(false); //36:87
            }
            __out.Append("    {"); //37:1
            __out.AppendLine(false); //37:6
            __out.Append("        public override string GetDataTipText(int line, int col, out TextSpan span)"); //38:1
            __out.AppendLine(false); //38:84
            __out.Append("        {"); //39:1
            __out.AppendLine(false); //39:10
            __out.Append("            span = new TextSpan();"); //40:1
            __out.AppendLine(false); //40:35
            __out.Append("            return null;"); //41:1
            __out.AppendLine(false); //41:25
            __out.Append("        }"); //42:1
            __out.AppendLine(false); //42:10
            __out.Append("        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)"); //43:1
            __out.AppendLine(false); //43:126
            __out.Append("        {"); //44:1
            __out.AppendLine(false); //44:10
            __out.Append("            return null;"); //45:1
            __out.AppendLine(false); //45:25
            __out.Append("        }"); //46:1
            __out.AppendLine(false); //46:10
            __out.Append("        public override Methods GetMethods(int line, int col, string name)"); //47:1
            __out.AppendLine(false); //47:75
            __out.Append("        {"); //48:1
            __out.AppendLine(false); //48:10
            __out.Append("            return null;"); //49:1
            __out.AppendLine(false); //49:25
            __out.Append("        }"); //50:1
            __out.AppendLine(false); //50:10
            __out.Append("        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)"); //51:1
            __out.AppendLine(false); //51:149
            __out.Append("        {"); //52:1
            __out.AppendLine(false); //52:10
            __out.Append("            span = new TextSpan();"); //53:1
            __out.AppendLine(false); //53:35
            __out.Append("            return null;"); //54:1
            __out.AppendLine(false); //54:25
            __out.Append("        }"); //55:1
            __out.AppendLine(false); //55:10
            __out.Append("    }"); //56:1
            __out.AppendLine(false); //56:6
            bool __tmp11_outputWritten = false;
            string __tmp12_line = "	public class "; //57:1
            if (!string.IsNullOrEmpty(__tmp12_line))
            {
                __out.Append(__tmp12_line);
                __tmp11_outputWritten = true;
            }
            StringBuilder __tmp13 = new StringBuilder();
            __tmp13.Append(Properties.LanguageClassName);
            using(StreamReader __tmp13Reader = new StreamReader(this.__ToStream(__tmp13.ToString())))
            {
                bool __tmp13_last = __tmp13Reader.EndOfStream;
                while(!__tmp13_last)
                {
                    string __tmp13_line = __tmp13Reader.ReadLine();
                    __tmp13_last = __tmp13Reader.EndOfStream;
                    if ((__tmp13_last && !string.IsNullOrEmpty(__tmp13_line)) || (!__tmp13_last && __tmp13_line != null))
                    {
                        __out.Append(__tmp13_line);
                        __tmp11_outputWritten = true;
                    }
                    if (!__tmp13_last) __out.AppendLine(true);
                }
            }
            string __tmp14_line = "LanguageColorizer : Colorizer"; //57:45
            if (!string.IsNullOrEmpty(__tmp14_line))
            {
                __out.Append(__tmp14_line);
                __tmp11_outputWritten = true;
            }
            if (__tmp11_outputWritten) __out.AppendLine(true);
            if (__tmp11_outputWritten)
            {
                __out.AppendLine(false); //57:74
            }
            __out.Append("    {"); //58:1
            __out.AppendLine(false); //58:6
            bool __tmp16_outputWritten = false;
            string __tmp17_line = "        public "; //59:1
            if (!string.IsNullOrEmpty(__tmp17_line))
            {
                __out.Append(__tmp17_line);
                __tmp16_outputWritten = true;
            }
            StringBuilder __tmp18 = new StringBuilder();
            __tmp18.Append(Properties.LanguageClassName);
            using(StreamReader __tmp18Reader = new StreamReader(this.__ToStream(__tmp18.ToString())))
            {
                bool __tmp18_last = __tmp18Reader.EndOfStream;
                while(!__tmp18_last)
                {
                    string __tmp18_line = __tmp18Reader.ReadLine();
                    __tmp18_last = __tmp18Reader.EndOfStream;
                    if ((__tmp18_last && !string.IsNullOrEmpty(__tmp18_line)) || (!__tmp18_last && __tmp18_line != null))
                    {
                        __out.Append(__tmp18_line);
                        __tmp16_outputWritten = true;
                    }
                    if (!__tmp18_last) __out.AppendLine(true);
                }
            }
            string __tmp19_line = "LanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)"; //59:46
            if (!string.IsNullOrEmpty(__tmp19_line))
            {
                __out.Append(__tmp19_line);
                __tmp16_outputWritten = true;
            }
            if (__tmp16_outputWritten) __out.AppendLine(true);
            if (__tmp16_outputWritten)
            {
                __out.AppendLine(false); //59:123
            }
            __out.Append("            : base(svc, buffer, scanner)"); //60:1
            __out.AppendLine(false); //60:41
            __out.Append("        {"); //61:1
            __out.AppendLine(false); //61:10
            __out.Append("        }"); //62:1
            __out.AppendLine(false); //62:10
            __out.Append("        #region IVsColorizer Members"); //63:1
            __out.AppendLine(false); //63:37
            bool __tmp21_outputWritten = false;
            string __tmp22_line = "        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint"; //64:1
            if (!string.IsNullOrEmpty(__tmp22_line))
            {
                __out.Append(__tmp22_line);
                __tmp21_outputWritten = true;
            }
            StringBuilder __tmp23 = new StringBuilder();
            __tmp23.Append("[]");
            using(StreamReader __tmp23Reader = new StreamReader(this.__ToStream(__tmp23.ToString())))
            {
                bool __tmp23_last = __tmp23Reader.EndOfStream;
                while(!__tmp23_last)
                {
                    string __tmp23_line = __tmp23Reader.ReadLine();
                    __tmp23_last = __tmp23Reader.EndOfStream;
                    if ((__tmp23_last && !string.IsNullOrEmpty(__tmp23_line)) || (!__tmp23_last && __tmp23_line != null))
                    {
                        __out.Append(__tmp23_line);
                        __tmp21_outputWritten = true;
                    }
                    if (!__tmp23_last) __out.AppendLine(true);
                }
            }
            string __tmp24_line = " attrs)"; //64:97
            if (!string.IsNullOrEmpty(__tmp24_line))
            {
                __out.Append(__tmp24_line);
                __tmp21_outputWritten = true;
            }
            if (__tmp21_outputWritten) __out.AppendLine(true);
            if (__tmp21_outputWritten)
            {
                __out.AppendLine(false); //64:104
            }
            __out.Append("        {"); //65:1
            __out.AppendLine(false); //65:10
            __out.Append("            if (attrs == null) return state;"); //66:1
            __out.AppendLine(false); //66:45
            __out.Append("            int linepos = 0;"); //67:1
            __out.AppendLine(false); //67:29
            __out.Append("            // Must initialize the colors in all cases, otherwise you get "); //68:1
            __out.AppendLine(false); //68:75
            __out.Append("            // random color junk on the screen."); //69:1
            __out.AppendLine(false); //69:48
            __out.Append("            for (linepos = 0; linepos < attrs.Length; linepos++)"); //70:1
            __out.AppendLine(false); //70:65
            bool __tmp26_outputWritten = false;
            string __tmp27_line = "                attrs"; //71:1
            if (!string.IsNullOrEmpty(__tmp27_line))
            {
                __out.Append(__tmp27_line);
                __tmp26_outputWritten = true;
            }
            StringBuilder __tmp28 = new StringBuilder();
            __tmp28.Append("[linepos]");
            using(StreamReader __tmp28Reader = new StreamReader(this.__ToStream(__tmp28.ToString())))
            {
                bool __tmp28_last = __tmp28Reader.EndOfStream;
                while(!__tmp28_last)
                {
                    string __tmp28_line = __tmp28Reader.ReadLine();
                    __tmp28_last = __tmp28Reader.EndOfStream;
                    if ((__tmp28_last && !string.IsNullOrEmpty(__tmp28_line)) || (!__tmp28_last && __tmp28_line != null))
                    {
                        __out.Append(__tmp28_line);
                        __tmp26_outputWritten = true;
                    }
                    if (!__tmp28_last) __out.AppendLine(true);
                }
            }
            string __tmp29_line = " = (uint)TokenColor.Text;"; //71:35
            if (!string.IsNullOrEmpty(__tmp29_line))
            {
                __out.Append(__tmp29_line);
                __tmp26_outputWritten = true;
            }
            if (__tmp26_outputWritten) __out.AppendLine(true);
            if (__tmp26_outputWritten)
            {
                __out.AppendLine(false); //71:60
            }
            __out.Append("            if (this.Scanner != null)"); //72:1
            __out.AppendLine(false); //72:38
            __out.Append("            {"); //73:1
            __out.AppendLine(false); //73:14
            __out.Append("                try"); //74:1
            __out.AppendLine(false); //74:20
            __out.Append("                {"); //75:1
            __out.AppendLine(false); //75:18
            __out.Append("                    string text = Marshal.PtrToStringUni(ptr, length);"); //76:1
            __out.AppendLine(false); //76:71
            __out.Append("                    this.Scanner.SetSource(text, 0);"); //77:1
            __out.AppendLine(false); //77:53
            __out.Append("                    TokenInfo tokenInfo = new TokenInfo();"); //78:1
            __out.AppendLine(false); //78:59
            __out.Append("                    tokenInfo.EndIndex = -1;"); //79:1
            __out.AppendLine(false); //79:45
            __out.Append("                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))"); //80:1
            __out.AppendLine(false); //80:94
            __out.Append("                    {"); //81:1
            __out.AppendLine(false); //81:22
            __out.Append("                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)"); //82:1
            __out.AppendLine(false); //82:103
            __out.Append("                        {"); //83:1
            __out.AppendLine(false); //83:26
            __out.Append("                            if (linepos >= 0 && linepos < attrs.Length)"); //84:1
            __out.AppendLine(false); //84:72
            __out.Append("                            {"); //85:1
            __out.AppendLine(false); //85:30
            bool __tmp31_outputWritten = false;
            string __tmp32_line = "                                attrs"; //86:1
            if (!string.IsNullOrEmpty(__tmp32_line))
            {
                __out.Append(__tmp32_line);
                __tmp31_outputWritten = true;
            }
            StringBuilder __tmp33 = new StringBuilder();
            __tmp33.Append("[linepos]");
            using(StreamReader __tmp33Reader = new StreamReader(this.__ToStream(__tmp33.ToString())))
            {
                bool __tmp33_last = __tmp33Reader.EndOfStream;
                while(!__tmp33_last)
                {
                    string __tmp33_line = __tmp33Reader.ReadLine();
                    __tmp33_last = __tmp33Reader.EndOfStream;
                    if ((__tmp33_last && !string.IsNullOrEmpty(__tmp33_line)) || (!__tmp33_last && __tmp33_line != null))
                    {
                        __out.Append(__tmp33_line);
                        __tmp31_outputWritten = true;
                    }
                    if (!__tmp33_last) __out.AppendLine(true);
                }
            }
            string __tmp34_line = " = (uint)tokenInfo.Color;"; //86:51
            if (!string.IsNullOrEmpty(__tmp34_line))
            {
                __out.Append(__tmp34_line);
                __tmp31_outputWritten = true;
            }
            if (__tmp31_outputWritten) __out.AppendLine(true);
            if (__tmp31_outputWritten)
            {
                __out.AppendLine(false); //86:76
            }
            __out.Append("                            }"); //87:1
            __out.AppendLine(false); //87:30
            __out.Append("                        }"); //88:1
            __out.AppendLine(false); //88:26
            __out.Append("                    }"); //89:1
            __out.AppendLine(false); //89:22
            __out.Append("                }"); //90:1
            __out.AppendLine(false); //90:18
            __out.Append("                catch (Exception)"); //91:1
            __out.AppendLine(false); //91:34
            __out.Append("                {"); //92:1
            __out.AppendLine(false); //92:18
            __out.Append("                    // Ignore exceptions"); //93:1
            __out.AppendLine(false); //93:41
            __out.Append("                }"); //94:1
            __out.AppendLine(false); //94:18
            __out.Append("            }"); //95:1
            __out.AppendLine(false); //95:14
            __out.Append("            return state;"); //96:1
            __out.AppendLine(false); //96:26
            __out.Append("        }"); //97:1
            __out.AppendLine(false); //97:10
            __out.Append("        public override int GetStartState(out int piStartState)"); //98:1
            __out.AppendLine(false); //98:64
            __out.Append("        {"); //99:1
            __out.AppendLine(false); //99:10
            __out.Append("            piStartState = 0;"); //100:1
            __out.AppendLine(false); //100:30
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //101:1
            __out.AppendLine(false); //101:60
            __out.Append("        }"); //102:1
            __out.AppendLine(false); //102:10
            __out.Append("        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)"); //103:1
            __out.AppendLine(false); //103:98
            __out.Append("        {"); //104:1
            __out.AppendLine(false); //104:10
            __out.Append("            string text = Marshal.PtrToStringUni(pText, iLength);"); //105:1
            __out.AppendLine(false); //105:66
            __out.Append("            if (text != null)"); //106:1
            __out.AppendLine(false); //106:30
            __out.Append("            {"); //107:1
            __out.AppendLine(false); //107:14
            __out.Append("                this.Scanner.SetSource(text, 0);"); //108:1
            __out.AppendLine(false); //108:49
            bool __tmp36_outputWritten = false;
            string __tmp37_line = "                (("; //109:1
            if (!string.IsNullOrEmpty(__tmp37_line))
            {
                __out.Append(__tmp37_line);
                __tmp36_outputWritten = true;
            }
            StringBuilder __tmp38 = new StringBuilder();
            __tmp38.Append(Properties.LanguageClassName);
            using(StreamReader __tmp38Reader = new StreamReader(this.__ToStream(__tmp38.ToString())))
            {
                bool __tmp38_last = __tmp38Reader.EndOfStream;
                while(!__tmp38_last)
                {
                    string __tmp38_line = __tmp38Reader.ReadLine();
                    __tmp38_last = __tmp38Reader.EndOfStream;
                    if ((__tmp38_last && !string.IsNullOrEmpty(__tmp38_line)) || (!__tmp38_last && __tmp38_line != null))
                    {
                        __out.Append(__tmp38_line);
                        __tmp36_outputWritten = true;
                    }
                    if (!__tmp38_last) __out.AppendLine(true);
                }
            }
            string __tmp39_line = "LanguageScanner)this.Scanner).ScanLine(ref iState);"; //109:49
            if (!string.IsNullOrEmpty(__tmp39_line))
            {
                __out.Append(__tmp39_line);
                __tmp36_outputWritten = true;
            }
            if (__tmp36_outputWritten) __out.AppendLine(true);
            if (__tmp36_outputWritten)
            {
                __out.AppendLine(false); //109:100
            }
            __out.Append("            }"); //110:1
            __out.AppendLine(false); //110:14
            __out.Append("            return iState;"); //111:1
            __out.AppendLine(false); //111:27
            __out.Append("        }"); //112:1
            __out.AppendLine(false); //112:10
            __out.Append("        public override int GetStateMaintenanceFlag(out int pfFlag)"); //113:1
            __out.AppendLine(false); //113:68
            __out.Append("        {"); //114:1
            __out.AppendLine(false); //114:10
            __out.Append("            pfFlag = 1;"); //115:1
            __out.AppendLine(false); //115:24
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //116:1
            __out.AppendLine(false); //116:60
            __out.Append("        }"); //117:1
            __out.AppendLine(false); //117:10
            __out.Append("        #endregion"); //118:1
            __out.AppendLine(false); //118:19
            __out.Append("    }"); //119:1
            __out.AppendLine(false); //119:6
            bool __tmp41_outputWritten = false;
            string __tmp42_line = "    public abstract class "; //120:1
            if (!string.IsNullOrEmpty(__tmp42_line))
            {
                __out.Append(__tmp42_line);
                __tmp41_outputWritten = true;
            }
            StringBuilder __tmp43 = new StringBuilder();
            __tmp43.Append(Properties.LanguageClassName);
            using(StreamReader __tmp43Reader = new StreamReader(this.__ToStream(__tmp43.ToString())))
            {
                bool __tmp43_last = __tmp43Reader.EndOfStream;
                while(!__tmp43_last)
                {
                    string __tmp43_line = __tmp43Reader.ReadLine();
                    __tmp43_last = __tmp43Reader.EndOfStream;
                    if ((__tmp43_last && !string.IsNullOrEmpty(__tmp43_line)) || (!__tmp43_last && __tmp43_line != null))
                    {
                        __out.Append(__tmp43_line);
                        __tmp41_outputWritten = true;
                    }
                    if (!__tmp43_last) __out.AppendLine(true);
                }
            }
            string __tmp44_line = "LanguageConfigBase"; //120:57
            if (!string.IsNullOrEmpty(__tmp44_line))
            {
                __out.Append(__tmp44_line);
                __tmp41_outputWritten = true;
            }
            if (__tmp41_outputWritten) __out.AppendLine(true);
            if (__tmp41_outputWritten)
            {
                __out.AppendLine(false); //120:75
            }
            __out.Append("    {"); //121:1
            __out.AppendLine(false); //121:6
            bool __tmp46_outputWritten = false;
            string __tmp47_line = "        private static "; //122:1
            if (!string.IsNullOrEmpty(__tmp47_line))
            {
                __out.Append(__tmp47_line);
                __tmp46_outputWritten = true;
            }
            StringBuilder __tmp48 = new StringBuilder();
            __tmp48.Append(Properties.LanguageClassName);
            using(StreamReader __tmp48Reader = new StreamReader(this.__ToStream(__tmp48.ToString())))
            {
                bool __tmp48_last = __tmp48Reader.EndOfStream;
                while(!__tmp48_last)
                {
                    string __tmp48_line = __tmp48Reader.ReadLine();
                    __tmp48_last = __tmp48Reader.EndOfStream;
                    if ((__tmp48_last && !string.IsNullOrEmpty(__tmp48_line)) || (!__tmp48_last && __tmp48_line != null))
                    {
                        __out.Append(__tmp48_line);
                        __tmp46_outputWritten = true;
                    }
                    if (!__tmp48_last) __out.AppendLine(true);
                }
            }
            string __tmp49_line = "LanguageConfig instance = null;"; //122:54
            if (!string.IsNullOrEmpty(__tmp49_line))
            {
                __out.Append(__tmp49_line);
                __tmp46_outputWritten = true;
            }
            if (__tmp46_outputWritten) __out.AppendLine(true);
            if (__tmp46_outputWritten)
            {
                __out.AppendLine(false); //122:85
            }
            bool __tmp51_outputWritten = false;
            string __tmp52_line = "        public static "; //123:1
            if (!string.IsNullOrEmpty(__tmp52_line))
            {
                __out.Append(__tmp52_line);
                __tmp51_outputWritten = true;
            }
            StringBuilder __tmp53 = new StringBuilder();
            __tmp53.Append(Properties.LanguageClassName);
            using(StreamReader __tmp53Reader = new StreamReader(this.__ToStream(__tmp53.ToString())))
            {
                bool __tmp53_last = __tmp53Reader.EndOfStream;
                while(!__tmp53_last)
                {
                    string __tmp53_line = __tmp53Reader.ReadLine();
                    __tmp53_last = __tmp53Reader.EndOfStream;
                    if ((__tmp53_last && !string.IsNullOrEmpty(__tmp53_line)) || (!__tmp53_last && __tmp53_line != null))
                    {
                        __out.Append(__tmp53_line);
                        __tmp51_outputWritten = true;
                    }
                    if (!__tmp53_last) __out.AppendLine(true);
                }
            }
            string __tmp54_line = "LanguageConfig Instance"; //123:53
            if (!string.IsNullOrEmpty(__tmp54_line))
            {
                __out.Append(__tmp54_line);
                __tmp51_outputWritten = true;
            }
            if (__tmp51_outputWritten) __out.AppendLine(true);
            if (__tmp51_outputWritten)
            {
                __out.AppendLine(false); //123:76
            }
            __out.Append("        {"); //124:1
            __out.AppendLine(false); //124:10
            __out.Append("            get "); //125:1
            __out.AppendLine(false); //125:17
            __out.Append("            {"); //126:1
            __out.AppendLine(false); //126:14
            __out.Append("                if (instance == null)"); //127:1
            __out.AppendLine(false); //127:38
            __out.Append("                {"); //128:1
            __out.AppendLine(false); //128:18
            bool __tmp56_outputWritten = false;
            string __tmp57_line = "					// If there is a compile error in the following line, create a class "; //129:1
            if (!string.IsNullOrEmpty(__tmp57_line))
            {
                __out.Append(__tmp57_line);
                __tmp56_outputWritten = true;
            }
            StringBuilder __tmp58 = new StringBuilder();
            __tmp58.Append(Properties.LanguageClassName);
            using(StreamReader __tmp58Reader = new StreamReader(this.__ToStream(__tmp58.ToString())))
            {
                bool __tmp58_last = __tmp58Reader.EndOfStream;
                while(!__tmp58_last)
                {
                    string __tmp58_line = __tmp58Reader.ReadLine();
                    __tmp58_last = __tmp58Reader.EndOfStream;
                    if ((__tmp58_last && !string.IsNullOrEmpty(__tmp58_line)) || (!__tmp58_last && __tmp58_line != null))
                    {
                        __out.Append(__tmp58_line);
                        __tmp56_outputWritten = true;
                    }
                    if (!__tmp58_last) __out.AppendLine(true);
                }
            }
            string __tmp59_line = "LanguageConfig"; //129:105
            if (!string.IsNullOrEmpty(__tmp59_line))
            {
                __out.Append(__tmp59_line);
                __tmp56_outputWritten = true;
            }
            if (__tmp56_outputWritten) __out.AppendLine(true);
            if (__tmp56_outputWritten)
            {
                __out.AppendLine(false); //129:119
            }
            bool __tmp61_outputWritten = false;
            string __tmp62_line = "					// which is a subclass of "; //130:1
            if (!string.IsNullOrEmpty(__tmp62_line))
            {
                __out.Append(__tmp62_line);
                __tmp61_outputWritten = true;
            }
            StringBuilder __tmp63 = new StringBuilder();
            __tmp63.Append(Properties.LanguageClassName);
            using(StreamReader __tmp63Reader = new StreamReader(this.__ToStream(__tmp63.ToString())))
            {
                bool __tmp63_last = __tmp63Reader.EndOfStream;
                while(!__tmp63_last)
                {
                    string __tmp63_line = __tmp63Reader.ReadLine();
                    __tmp63_last = __tmp63Reader.EndOfStream;
                    if ((__tmp63_last && !string.IsNullOrEmpty(__tmp63_line)) || (!__tmp63_last && __tmp63_line != null))
                    {
                        __out.Append(__tmp63_line);
                        __tmp61_outputWritten = true;
                    }
                    if (!__tmp63_last) __out.AppendLine(true);
                }
            }
            string __tmp64_line = "LanguageConfigBase"; //130:62
            if (!string.IsNullOrEmpty(__tmp64_line))
            {
                __out.Append(__tmp64_line);
                __tmp61_outputWritten = true;
            }
            if (__tmp61_outputWritten) __out.AppendLine(true);
            if (__tmp61_outputWritten)
            {
                __out.AppendLine(false); //130:80
            }
            bool __tmp66_outputWritten = false;
            string __tmp67_line = "                    instance = new "; //131:1
            if (!string.IsNullOrEmpty(__tmp67_line))
            {
                __out.Append(__tmp67_line);
                __tmp66_outputWritten = true;
            }
            StringBuilder __tmp68 = new StringBuilder();
            __tmp68.Append(Properties.LanguageClassName);
            using(StreamReader __tmp68Reader = new StreamReader(this.__ToStream(__tmp68.ToString())))
            {
                bool __tmp68_last = __tmp68Reader.EndOfStream;
                while(!__tmp68_last)
                {
                    string __tmp68_line = __tmp68Reader.ReadLine();
                    __tmp68_last = __tmp68Reader.EndOfStream;
                    if ((__tmp68_last && !string.IsNullOrEmpty(__tmp68_line)) || (!__tmp68_last && __tmp68_line != null))
                    {
                        __out.Append(__tmp68_line);
                        __tmp66_outputWritten = true;
                    }
                    if (!__tmp68_last) __out.AppendLine(true);
                }
            }
            string __tmp69_line = "LanguageConfig();"; //131:66
            if (!string.IsNullOrEmpty(__tmp69_line))
            {
                __out.Append(__tmp69_line);
                __tmp66_outputWritten = true;
            }
            if (__tmp66_outputWritten) __out.AppendLine(true);
            if (__tmp66_outputWritten)
            {
                __out.AppendLine(false); //131:83
            }
            __out.Append("                }"); //132:1
            __out.AppendLine(false); //132:18
            __out.Append("                return instance;"); //133:1
            __out.AppendLine(false); //133:33
            __out.Append("            }"); //134:1
            __out.AppendLine(false); //134:14
            __out.Append("        }"); //135:1
            __out.AppendLine(false); //135:10
            bool __tmp71_outputWritten = false;
            string __tmp72_line = "        private List<"; //136:1
            if (!string.IsNullOrEmpty(__tmp72_line))
            {
                __out.Append(__tmp72_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp73 = new StringBuilder();
            __tmp73.Append(Properties.LanguageClassName);
            using(StreamReader __tmp73Reader = new StreamReader(this.__ToStream(__tmp73.ToString())))
            {
                bool __tmp73_last = __tmp73Reader.EndOfStream;
                while(!__tmp73_last)
                {
                    string __tmp73_line = __tmp73Reader.ReadLine();
                    __tmp73_last = __tmp73Reader.EndOfStream;
                    if ((__tmp73_last && !string.IsNullOrEmpty(__tmp73_line)) || (!__tmp73_last && __tmp73_line != null))
                    {
                        __out.Append(__tmp73_line);
                        __tmp71_outputWritten = true;
                    }
                    if (!__tmp73_last) __out.AppendLine(true);
                }
            }
            string __tmp74_line = "LanguageColorableItem> colorableItems = new List<"; //136:52
            if (!string.IsNullOrEmpty(__tmp74_line))
            {
                __out.Append(__tmp74_line);
                __tmp71_outputWritten = true;
            }
            StringBuilder __tmp75 = new StringBuilder();
            __tmp75.Append(Properties.LanguageClassName);
            using(StreamReader __tmp75Reader = new StreamReader(this.__ToStream(__tmp75.ToString())))
            {
                bool __tmp75_last = __tmp75Reader.EndOfStream;
                while(!__tmp75_last)
                {
                    string __tmp75_line = __tmp75Reader.ReadLine();
                    __tmp75_last = __tmp75Reader.EndOfStream;
                    if ((__tmp75_last && !string.IsNullOrEmpty(__tmp75_line)) || (!__tmp75_last && __tmp75_line != null))
                    {
                        __out.Append(__tmp75_line);
                        __tmp71_outputWritten = true;
                    }
                    if (!__tmp75_last) __out.AppendLine(true);
                }
            }
            string __tmp76_line = "LanguageColorableItem>();"; //136:131
            if (!string.IsNullOrEmpty(__tmp76_line))
            {
                __out.Append(__tmp76_line);
                __tmp71_outputWritten = true;
            }
            if (__tmp71_outputWritten) __out.AppendLine(true);
            if (__tmp71_outputWritten)
            {
                __out.AppendLine(false); //136:156
            }
            bool __tmp78_outputWritten = false;
            string __tmp79_line = "        public IList<"; //137:1
            if (!string.IsNullOrEmpty(__tmp79_line))
            {
                __out.Append(__tmp79_line);
                __tmp78_outputWritten = true;
            }
            StringBuilder __tmp80 = new StringBuilder();
            __tmp80.Append(Properties.LanguageClassName);
            using(StreamReader __tmp80Reader = new StreamReader(this.__ToStream(__tmp80.ToString())))
            {
                bool __tmp80_last = __tmp80Reader.EndOfStream;
                while(!__tmp80_last)
                {
                    string __tmp80_line = __tmp80Reader.ReadLine();
                    __tmp80_last = __tmp80Reader.EndOfStream;
                    if ((__tmp80_last && !string.IsNullOrEmpty(__tmp80_line)) || (!__tmp80_last && __tmp80_line != null))
                    {
                        __out.Append(__tmp80_line);
                        __tmp78_outputWritten = true;
                    }
                    if (!__tmp80_last) __out.AppendLine(true);
                }
            }
            string __tmp81_line = "LanguageColorableItem> ColorableItems"; //137:52
            if (!string.IsNullOrEmpty(__tmp81_line))
            {
                __out.Append(__tmp81_line);
                __tmp78_outputWritten = true;
            }
            if (__tmp78_outputWritten) __out.AppendLine(true);
            if (__tmp78_outputWritten)
            {
                __out.AppendLine(false); //137:89
            }
            __out.Append("        {"); //138:1
            __out.AppendLine(false); //138:10
            __out.Append("            get { return colorableItems; }"); //139:1
            __out.AppendLine(false); //139:43
            __out.Append("        }"); //140:1
            __out.AppendLine(false); //140:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)"); //141:1
            __out.AppendLine(false); //141:93
            __out.Append("        {"); //142:1
            __out.AppendLine(false); //142:10
            __out.Append("            return CreateColor(name, type, foregroundColor, false, false);"); //143:1
            __out.AppendLine(false); //143:75
            __out.Append("        }"); //144:1
            __out.AppendLine(false); //144:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)"); //145:1
            __out.AppendLine(false); //145:98
            __out.Append("        {"); //146:1
            __out.AppendLine(false); //146:10
            __out.Append("            return CreateColor(name, type, foregroundIndex, false, false);"); //147:1
            __out.AppendLine(false); //147:75
            __out.Append("        }"); //148:1
            __out.AppendLine(false); //148:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)"); //149:1
            __out.AppendLine(false); //149:124
            __out.Append("        {"); //150:1
            __out.AppendLine(false); //150:10
            bool __tmp83_outputWritten = false;
            string __tmp84_line = "            colorableItems.Add(new "; //151:1
            if (!string.IsNullOrEmpty(__tmp84_line))
            {
                __out.Append(__tmp84_line);
                __tmp83_outputWritten = true;
            }
            StringBuilder __tmp85 = new StringBuilder();
            __tmp85.Append(Properties.LanguageClassName);
            using(StreamReader __tmp85Reader = new StreamReader(this.__ToStream(__tmp85.ToString())))
            {
                bool __tmp85_last = __tmp85Reader.EndOfStream;
                while(!__tmp85_last)
                {
                    string __tmp85_line = __tmp85Reader.ReadLine();
                    __tmp85_last = __tmp85Reader.EndOfStream;
                    if ((__tmp85_last && !string.IsNullOrEmpty(__tmp85_line)) || (!__tmp85_last && __tmp85_line != null))
                    {
                        __out.Append(__tmp85_line);
                        __tmp83_outputWritten = true;
                    }
                    if (!__tmp85_last) __out.AppendLine(true);
                }
            }
            string __tmp86_line = "LanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));"; //151:66
            if (!string.IsNullOrEmpty(__tmp86_line))
            {
                __out.Append(__tmp86_line);
                __tmp83_outputWritten = true;
            }
            if (__tmp83_outputWritten) __out.AppendLine(true);
            if (__tmp83_outputWritten)
            {
                __out.AppendLine(false); //151:197
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //152:1
            __out.AppendLine(false); //152:53
            __out.Append("        }"); //153:1
            __out.AppendLine(false); //153:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)"); //154:1
            __out.AppendLine(false); //154:129
            __out.Append("        {"); //155:1
            __out.AppendLine(false); //155:10
            bool __tmp88_outputWritten = false;
            string __tmp89_line = "            colorableItems.Add(new "; //156:1
            if (!string.IsNullOrEmpty(__tmp89_line))
            {
                __out.Append(__tmp89_line);
                __tmp88_outputWritten = true;
            }
            StringBuilder __tmp90 = new StringBuilder();
            __tmp90.Append(Properties.LanguageClassName);
            using(StreamReader __tmp90Reader = new StreamReader(this.__ToStream(__tmp90.ToString())))
            {
                bool __tmp90_last = __tmp90Reader.EndOfStream;
                while(!__tmp90_last)
                {
                    string __tmp90_line = __tmp90Reader.ReadLine();
                    __tmp90_last = __tmp90Reader.EndOfStream;
                    if ((__tmp90_last && !string.IsNullOrEmpty(__tmp90_line)) || (!__tmp90_last && __tmp90_line != null))
                    {
                        __out.Append(__tmp90_line);
                        __tmp88_outputWritten = true;
                    }
                    if (!__tmp90_last) __out.AppendLine(true);
                }
            }
            string __tmp91_line = "LanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));"; //156:66
            if (!string.IsNullOrEmpty(__tmp91_line))
            {
                __out.Append(__tmp91_line);
                __tmp88_outputWritten = true;
            }
            if (__tmp88_outputWritten) __out.AppendLine(true);
            if (__tmp88_outputWritten)
            {
                __out.AppendLine(false); //156:192
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //157:1
            __out.AppendLine(false); //157:53
            __out.Append("        }"); //158:1
            __out.AppendLine(false); //158:10
            __out.Append("        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"); //159:1
            __out.AppendLine(false); //159:203
            __out.Append("        {"); //160:1
            __out.AppendLine(false); //160:10
            bool __tmp93_outputWritten = false;
            string __tmp94_line = "            colorableItems.Add(new "; //161:1
            if (!string.IsNullOrEmpty(__tmp94_line))
            {
                __out.Append(__tmp94_line);
                __tmp93_outputWritten = true;
            }
            StringBuilder __tmp95 = new StringBuilder();
            __tmp95.Append(Properties.LanguageClassName);
            using(StreamReader __tmp95Reader = new StreamReader(this.__ToStream(__tmp95.ToString())))
            {
                bool __tmp95_last = __tmp95Reader.EndOfStream;
                while(!__tmp95_last)
                {
                    string __tmp95_line = __tmp95Reader.ReadLine();
                    __tmp95_last = __tmp95Reader.EndOfStream;
                    if ((__tmp95_last && !string.IsNullOrEmpty(__tmp95_line)) || (!__tmp95_last && __tmp95_line != null))
                    {
                        __out.Append(__tmp95_line);
                        __tmp93_outputWritten = true;
                    }
                    if (!__tmp95_last) __out.AppendLine(true);
                }
            }
            string __tmp96_line = "LanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));"; //161:66
            if (!string.IsNullOrEmpty(__tmp96_line))
            {
                __out.Append(__tmp96_line);
                __tmp93_outputWritten = true;
            }
            if (__tmp93_outputWritten) __out.AppendLine(true);
            if (__tmp93_outputWritten)
            {
                __out.AppendLine(false); //161:190
            }
            __out.Append("            return (TokenColor)colorableItems.Count;"); //162:1
            __out.AppendLine(false); //162:53
            __out.Append("        }"); //163:1
            __out.AppendLine(false); //163:10
            __out.Append("    }"); //164:1
            __out.AppendLine(false); //164:6
            bool __tmp98_outputWritten = false;
            string __tmp99_line = "    public class "; //165:1
            if (!string.IsNullOrEmpty(__tmp99_line))
            {
                __out.Append(__tmp99_line);
                __tmp98_outputWritten = true;
            }
            StringBuilder __tmp100 = new StringBuilder();
            __tmp100.Append(Properties.LanguageClassName);
            using(StreamReader __tmp100Reader = new StreamReader(this.__ToStream(__tmp100.ToString())))
            {
                bool __tmp100_last = __tmp100Reader.EndOfStream;
                while(!__tmp100_last)
                {
                    string __tmp100_line = __tmp100Reader.ReadLine();
                    __tmp100_last = __tmp100Reader.EndOfStream;
                    if ((__tmp100_last && !string.IsNullOrEmpty(__tmp100_line)) || (!__tmp100_last && __tmp100_line != null))
                    {
                        __out.Append(__tmp100_line);
                        __tmp98_outputWritten = true;
                    }
                    if (!__tmp100_last) __out.AppendLine(true);
                }
            }
            string __tmp101_line = "LanguageColorableItem : IVsColorableItem, IVsHiColorItem"; //165:48
            if (!string.IsNullOrEmpty(__tmp101_line))
            {
                __out.Append(__tmp101_line);
                __tmp98_outputWritten = true;
            }
            if (__tmp98_outputWritten) __out.AppendLine(true);
            if (__tmp98_outputWritten)
            {
                __out.AppendLine(false); //165:104
            }
            __out.Append("    {"); //166:1
            __out.AppendLine(false); //166:6
            __out.Append("        // Indicates that the returned RGB value is really an index"); //167:1
            __out.AppendLine(false); //167:68
            __out.Append("        // into a predefined list of colors."); //168:1
            __out.AppendLine(false); //168:45
            __out.Append("        private const uint COLOR_INDEXED = 0x01000000;"); //169:1
            __out.AppendLine(false); //169:55
            __out.Append("        public string DisplayName { get; private set; }"); //170:1
            __out.AppendLine(false); //170:56
            __out.Append("        public TokenType TokenType { get; private set; }"); //171:1
            __out.AppendLine(false); //171:57
            __out.Append("        public COLORINDEX BackgroundIndex { get; private set; }"); //172:1
            __out.AppendLine(false); //172:64
            __out.Append("        public COLORINDEX ForegroundIndex { get; private set; }"); //173:1
            __out.AppendLine(false); //173:64
            __out.Append("        public uint BackgroundColor { get; private set; }"); //174:1
            __out.AppendLine(false); //174:58
            __out.Append("        public uint ForegroundColor { get; private set; }"); //175:1
            __out.AppendLine(false); //175:58
            __out.Append("        public uint FontFlags { get; private set; }"); //176:1
            __out.AppendLine(false); //176:52
            bool __tmp103_outputWritten = false;
            string __tmp104_line = "        public "; //177:1
            if (!string.IsNullOrEmpty(__tmp104_line))
            {
                __out.Append(__tmp104_line);
                __tmp103_outputWritten = true;
            }
            StringBuilder __tmp105 = new StringBuilder();
            __tmp105.Append(Properties.LanguageClassName);
            using(StreamReader __tmp105Reader = new StreamReader(this.__ToStream(__tmp105.ToString())))
            {
                bool __tmp105_last = __tmp105Reader.EndOfStream;
                while(!__tmp105_last)
                {
                    string __tmp105_line = __tmp105Reader.ReadLine();
                    __tmp105_last = __tmp105Reader.EndOfStream;
                    if ((__tmp105_last && !string.IsNullOrEmpty(__tmp105_line)) || (!__tmp105_last && __tmp105_line != null))
                    {
                        __out.Append(__tmp105_line);
                        __tmp103_outputWritten = true;
                    }
                    if (!__tmp105_last) __out.AppendLine(true);
                }
            }
            string __tmp106_line = "LanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)"; //177:46
            if (!string.IsNullOrEmpty(__tmp106_line))
            {
                __out.Append(__tmp106_line);
                __tmp103_outputWritten = true;
            }
            if (__tmp103_outputWritten) __out.AppendLine(true);
            if (__tmp103_outputWritten)
            {
                __out.AppendLine(false); //177:241
            }
            __out.Append("        {"); //178:1
            __out.AppendLine(false); //178:10
            __out.Append("            this.DisplayName = displayName;"); //179:1
            __out.AppendLine(false); //179:44
            __out.Append("            this.TokenType = tokenType;"); //180:1
            __out.AppendLine(false); //180:40
            __out.Append("            this.BackgroundIndex = backgroundIndex;"); //181:1
            __out.AppendLine(false); //181:52
            __out.Append("            this.ForegroundIndex = foregroundIndex;"); //182:1
            __out.AppendLine(false); //182:52
            __out.Append("            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);"); //183:1
            __out.AppendLine(false); //183:98
            __out.Append("            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);"); //184:1
            __out.AppendLine(false); //184:98
            __out.Append("            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;"); //185:1
            __out.AppendLine(false); //185:57
            __out.Append("            if (bold)"); //186:1
            __out.AppendLine(false); //186:22
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;"); //187:1
            __out.AppendLine(false); //187:75
            __out.Append("            if (strikethrough)"); //188:1
            __out.AppendLine(false); //188:31
            __out.Append("                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;"); //189:1
            __out.AppendLine(false); //189:84
            __out.Append("        }"); //190:1
            __out.AppendLine(false); //190:10
            __out.Append("        #region IVsColorableItem Members"); //191:1
            __out.AppendLine(false); //191:41
            bool __tmp108_outputWritten = false;
            string __tmp109_line = "        public int GetDefaultColors(COLORINDEX"; //192:1
            if (!string.IsNullOrEmpty(__tmp109_line))
            {
                __out.Append(__tmp109_line);
                __tmp108_outputWritten = true;
            }
            StringBuilder __tmp110 = new StringBuilder();
            __tmp110.Append("[]");
            using(StreamReader __tmp110Reader = new StreamReader(this.__ToStream(__tmp110.ToString())))
            {
                bool __tmp110_last = __tmp110Reader.EndOfStream;
                while(!__tmp110_last)
                {
                    string __tmp110_line = __tmp110Reader.ReadLine();
                    __tmp110_last = __tmp110Reader.EndOfStream;
                    if ((__tmp110_last && !string.IsNullOrEmpty(__tmp110_line)) || (!__tmp110_last && __tmp110_line != null))
                    {
                        __out.Append(__tmp110_line);
                        __tmp108_outputWritten = true;
                    }
                    if (!__tmp110_last) __out.AppendLine(true);
                }
            }
            string __tmp111_line = " piForeground, COLORINDEX"; //192:53
            if (!string.IsNullOrEmpty(__tmp111_line))
            {
                __out.Append(__tmp111_line);
                __tmp108_outputWritten = true;
            }
            StringBuilder __tmp112 = new StringBuilder();
            __tmp112.Append("[]");
            using(StreamReader __tmp112Reader = new StreamReader(this.__ToStream(__tmp112.ToString())))
            {
                bool __tmp112_last = __tmp112Reader.EndOfStream;
                while(!__tmp112_last)
                {
                    string __tmp112_line = __tmp112Reader.ReadLine();
                    __tmp112_last = __tmp112Reader.EndOfStream;
                    if ((__tmp112_last && !string.IsNullOrEmpty(__tmp112_line)) || (!__tmp112_last && __tmp112_line != null))
                    {
                        __out.Append(__tmp112_line);
                        __tmp108_outputWritten = true;
                    }
                    if (!__tmp112_last) __out.AppendLine(true);
                }
            }
            string __tmp113_line = " piBackground)"; //192:84
            if (!string.IsNullOrEmpty(__tmp113_line))
            {
                __out.Append(__tmp113_line);
                __tmp108_outputWritten = true;
            }
            if (__tmp108_outputWritten) __out.AppendLine(true);
            if (__tmp108_outputWritten)
            {
                __out.AppendLine(false); //192:98
            }
            __out.Append("        {"); //193:1
            __out.AppendLine(false); //193:10
            __out.Append("            if (null == piForeground)"); //194:1
            __out.AppendLine(false); //194:38
            __out.Append("            {"); //195:1
            __out.AppendLine(false); //195:14
            __out.Append("                throw new ArgumentNullException(\"piForeground\");"); //196:1
            __out.AppendLine(false); //196:65
            __out.Append("            }"); //197:1
            __out.AppendLine(false); //197:14
            __out.Append("            if (0 == piForeground.Length)"); //198:1
            __out.AppendLine(false); //198:42
            __out.Append("            {"); //199:1
            __out.AppendLine(false); //199:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piForeground\");"); //200:1
            __out.AppendLine(false); //200:71
            __out.Append("            }"); //201:1
            __out.AppendLine(false); //201:14
            bool __tmp115_outputWritten = false;
            string __tmp116_line = "            piForeground"; //202:1
            if (!string.IsNullOrEmpty(__tmp116_line))
            {
                __out.Append(__tmp116_line);
                __tmp115_outputWritten = true;
            }
            StringBuilder __tmp117 = new StringBuilder();
            __tmp117.Append("[0]");
            using(StreamReader __tmp117Reader = new StreamReader(this.__ToStream(__tmp117.ToString())))
            {
                bool __tmp117_last = __tmp117Reader.EndOfStream;
                while(!__tmp117_last)
                {
                    string __tmp117_line = __tmp117Reader.ReadLine();
                    __tmp117_last = __tmp117Reader.EndOfStream;
                    if ((__tmp117_last && !string.IsNullOrEmpty(__tmp117_line)) || (!__tmp117_last && __tmp117_line != null))
                    {
                        __out.Append(__tmp117_line);
                        __tmp115_outputWritten = true;
                    }
                    if (!__tmp117_last) __out.AppendLine(true);
                }
            }
            string __tmp118_line = " = this.ForegroundIndex;"; //202:32
            if (!string.IsNullOrEmpty(__tmp118_line))
            {
                __out.Append(__tmp118_line);
                __tmp115_outputWritten = true;
            }
            if (__tmp115_outputWritten) __out.AppendLine(true);
            if (__tmp115_outputWritten)
            {
                __out.AppendLine(false); //202:56
            }
            __out.Append("            if (null == piBackground)"); //203:1
            __out.AppendLine(false); //203:38
            __out.Append("            {"); //204:1
            __out.AppendLine(false); //204:14
            __out.Append("                throw new ArgumentNullException(\"piBackground\");"); //205:1
            __out.AppendLine(false); //205:65
            __out.Append("            }"); //206:1
            __out.AppendLine(false); //206:14
            __out.Append("            if (0 == piBackground.Length)"); //207:1
            __out.AppendLine(false); //207:42
            __out.Append("            {"); //208:1
            __out.AppendLine(false); //208:14
            __out.Append("                throw new ArgumentOutOfRangeException(\"piBackground\");"); //209:1
            __out.AppendLine(false); //209:71
            __out.Append("            }"); //210:1
            __out.AppendLine(false); //210:14
            bool __tmp120_outputWritten = false;
            string __tmp121_line = "            piBackground"; //211:1
            if (!string.IsNullOrEmpty(__tmp121_line))
            {
                __out.Append(__tmp121_line);
                __tmp120_outputWritten = true;
            }
            StringBuilder __tmp122 = new StringBuilder();
            __tmp122.Append("[0]");
            using(StreamReader __tmp122Reader = new StreamReader(this.__ToStream(__tmp122.ToString())))
            {
                bool __tmp122_last = __tmp122Reader.EndOfStream;
                while(!__tmp122_last)
                {
                    string __tmp122_line = __tmp122Reader.ReadLine();
                    __tmp122_last = __tmp122Reader.EndOfStream;
                    if ((__tmp122_last && !string.IsNullOrEmpty(__tmp122_line)) || (!__tmp122_last && __tmp122_line != null))
                    {
                        __out.Append(__tmp122_line);
                        __tmp120_outputWritten = true;
                    }
                    if (!__tmp122_last) __out.AppendLine(true);
                }
            }
            string __tmp123_line = " = this.BackgroundIndex;"; //211:32
            if (!string.IsNullOrEmpty(__tmp123_line))
            {
                __out.Append(__tmp123_line);
                __tmp120_outputWritten = true;
            }
            if (__tmp120_outputWritten) __out.AppendLine(true);
            if (__tmp120_outputWritten)
            {
                __out.AppendLine(false); //211:56
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //212:1
            __out.AppendLine(false); //212:60
            __out.Append("        }"); //213:1
            __out.AppendLine(false); //213:10
            __out.Append("        public int GetDefaultFontFlags(out uint pdwFontFlags)"); //214:1
            __out.AppendLine(false); //214:62
            __out.Append("        {"); //215:1
            __out.AppendLine(false); //215:10
            __out.Append("            pdwFontFlags = this.FontFlags;"); //216:1
            __out.AppendLine(false); //216:43
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //217:1
            __out.AppendLine(false); //217:60
            __out.Append("        }"); //218:1
            __out.AppendLine(false); //218:10
            __out.Append("        public int GetDisplayName(out string pbstrName)"); //219:1
            __out.AppendLine(false); //219:56
            __out.Append("        {"); //220:1
            __out.AppendLine(false); //220:10
            __out.Append("            pbstrName = this.DisplayName;"); //221:1
            __out.AppendLine(false); //221:42
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //222:1
            __out.AppendLine(false); //222:60
            __out.Append("        }"); //223:1
            __out.AppendLine(false); //223:10
            __out.Append("        public int GetColorData(int cdElement, out uint pcrColor)"); //224:1
            __out.AppendLine(false); //224:66
            __out.Append("        {"); //225:1
            __out.AppendLine(false); //225:10
            __out.Append("            int retval = VSConstants.E_NOTIMPL;"); //226:1
            __out.AppendLine(false); //226:48
            __out.Append("            pcrColor = 0;"); //227:1
            __out.AppendLine(false); //227:26
            __out.Append("            switch ((__tagVSCOLORDATA)cdElement)"); //228:1
            __out.AppendLine(false); //228:49
            __out.Append("            {"); //229:1
            __out.AppendLine(false); //229:14
            __out.Append("                case __tagVSCOLORDATA.CD_BACKGROUND:"); //230:1
            __out.AppendLine(false); //230:53
            __out.Append("                    pcrColor = this.BackgroundIndex > 0 ?"); //231:1
            __out.AppendLine(false); //231:58
            __out.Append("                                   (uint)this.BackgroundIndex | COLOR_INDEXED"); //232:1
            __out.AppendLine(false); //232:78
            __out.Append("                                   : this.BackgroundColor;"); //233:1
            __out.AppendLine(false); //233:59
            __out.Append("                    retval = VSConstants.S_OK;"); //234:1
            __out.AppendLine(false); //234:47
            __out.Append("                    break;"); //235:1
            __out.AppendLine(false); //235:27
            __out.Append("                case __tagVSCOLORDATA.CD_FOREGROUND:"); //236:1
            __out.AppendLine(false); //236:53
            __out.Append("                case __tagVSCOLORDATA.CD_LINECOLOR:"); //237:1
            __out.AppendLine(false); //237:52
            __out.Append("                    pcrColor = this.ForegroundIndex > 0 ?"); //238:1
            __out.AppendLine(false); //238:58
            __out.Append("                                   (uint)this.ForegroundIndex | COLOR_INDEXED"); //239:1
            __out.AppendLine(false); //239:78
            __out.Append("                                   : this.ForegroundColor;"); //240:1
            __out.AppendLine(false); //240:59
            __out.Append("                    retval = VSConstants.S_OK;"); //241:1
            __out.AppendLine(false); //241:47
            __out.Append("                    break;"); //242:1
            __out.AppendLine(false); //242:27
            __out.Append("                default:"); //243:1
            __out.AppendLine(false); //243:25
            __out.Append("                    retval = VSConstants.E_INVALIDARG;"); //244:1
            __out.AppendLine(false); //244:55
            __out.Append("                    break;"); //245:1
            __out.AppendLine(false); //245:27
            __out.Append("            }"); //246:1
            __out.AppendLine(false); //246:14
            __out.Append("            return retval;"); //247:1
            __out.AppendLine(false); //247:27
            __out.Append("        }"); //248:1
            __out.AppendLine(false); //248:10
            __out.Append("        #endregion"); //249:1
            __out.AppendLine(false); //249:19
            __out.Append("    }"); //250:1
            __out.AppendLine(false); //250:6
            bool __tmp125_outputWritten = false;
            string __tmp124Prefix = "    "; //251:1
            StringBuilder __tmp126 = new StringBuilder();
            __tmp126.Append("[ComVisible(true)]");
            using(StreamReader __tmp126Reader = new StreamReader(this.__ToStream(__tmp126.ToString())))
            {
                bool __tmp126_last = __tmp126Reader.EndOfStream;
                while(!__tmp126_last)
                {
                    string __tmp126_line = __tmp126Reader.ReadLine();
                    __tmp126_last = __tmp126Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp124Prefix))
                    {
                        __out.Append(__tmp124Prefix);
                        __tmp125_outputWritten = true;
                    }
                    if ((__tmp126_last && !string.IsNullOrEmpty(__tmp126_line)) || (!__tmp126_last && __tmp126_line != null))
                    {
                        __out.Append(__tmp126_line);
                        __tmp125_outputWritten = true;
                    }
                    if (!__tmp126_last || __tmp125_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp125_outputWritten)
            {
                __out.AppendLine(false); //251:27
            }
            bool __tmp128_outputWritten = false;
            string __tmp127Prefix = "    "; //252:1
            StringBuilder __tmp129 = new StringBuilder();
            __tmp129.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "GeneratorServiceGuid)]");
            using(StreamReader __tmp129Reader = new StreamReader(this.__ToStream(__tmp129.ToString())))
            {
                bool __tmp129_last = __tmp129Reader.EndOfStream;
                while(!__tmp129_last)
                {
                    string __tmp129_line = __tmp129Reader.ReadLine();
                    __tmp129_last = __tmp129Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp127Prefix))
                    {
                        __out.Append(__tmp127Prefix);
                        __tmp128_outputWritten = true;
                    }
                    if ((__tmp129_last && !string.IsNullOrEmpty(__tmp129_line)) || (!__tmp129_last && __tmp129_line != null))
                    {
                        __out.Append(__tmp129_line);
                        __tmp128_outputWritten = true;
                    }
                    if (!__tmp129_last || __tmp128_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp128_outputWritten)
            {
                __out.AppendLine(false); //252:116
            }
            bool __tmp131_outputWritten = false;
            string __tmp130Prefix = "    "; //253:1
            StringBuilder __tmp132 = new StringBuilder();
            __tmp132.Append("[ProvideObject(typeof(" + Properties.LanguageClassName + "GeneratorService), RegisterUsing = RegistrationMethod.CodeBase)]");
            using(StreamReader __tmp132Reader = new StreamReader(this.__ToStream(__tmp132.ToString())))
            {
                bool __tmp132_last = __tmp132Reader.EndOfStream;
                while(!__tmp132_last)
                {
                    string __tmp132_line = __tmp132Reader.ReadLine();
                    __tmp132_last = __tmp132Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp130Prefix))
                    {
                        __out.Append(__tmp130Prefix);
                        __tmp131_outputWritten = true;
                    }
                    if ((__tmp132_last && !string.IsNullOrEmpty(__tmp132_line)) || (!__tmp132_last && __tmp132_line != null))
                    {
                        __out.Append(__tmp132_line);
                        __tmp131_outputWritten = true;
                    }
                    if (!__tmp132_last || __tmp131_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp131_outputWritten)
            {
                __out.AppendLine(false); //253:127
            }
            bool __tmp134_outputWritten = false;
            string __tmp133Prefix = "    "; //254:1
            StringBuilder __tmp135 = new StringBuilder();
            __tmp135.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.FileExtension)]");
            using(StreamReader __tmp135Reader = new StreamReader(this.__ToStream(__tmp135.ToString())))
            {
                bool __tmp135_last = __tmp135Reader.EndOfStream;
                while(!__tmp135_last)
                {
                    string __tmp135_line = __tmp135Reader.ReadLine();
                    __tmp135_last = __tmp135Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp133Prefix))
                    {
                        __out.Append(__tmp133Prefix);
                        __tmp134_outputWritten = true;
                    }
                    if ((__tmp135_last && !string.IsNullOrEmpty(__tmp135_line)) || (!__tmp135_last && __tmp135_line != null))
                    {
                        __out.Append(__tmp135_line);
                        __tmp134_outputWritten = true;
                    }
                    if (!__tmp135_last || __tmp134_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp134_outputWritten)
            {
                __out.AppendLine(false); //254:284
            }
            bool __tmp137_outputWritten = false;
            string __tmp136Prefix = "    "; //255:1
            StringBuilder __tmp138 = new StringBuilder();
            __tmp138.Append("[CodeGeneratorRegistration(typeof(" + Properties.LanguageClassName + "GeneratorService), " + Properties.LanguageClassName + "LanguageConfig.GeneratorServiceName, \"{fae04ec1-301f-11d3-bf4b-00c04f79efbc}\", GeneratorRegKeyName = " + Properties.LanguageClassName + "LanguageConfig.GeneratorName, GeneratesDesignTimeSource = true)]");
            using(StreamReader __tmp138Reader = new StreamReader(this.__ToStream(__tmp138.ToString())))
            {
                bool __tmp138_last = __tmp138Reader.EndOfStream;
                while(!__tmp138_last)
                {
                    string __tmp138_line = __tmp138Reader.ReadLine();
                    __tmp138_last = __tmp138Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp136Prefix))
                    {
                        __out.Append(__tmp136Prefix);
                        __tmp137_outputWritten = true;
                    }
                    if ((__tmp138_last && !string.IsNullOrEmpty(__tmp138_line)) || (!__tmp138_last && __tmp138_line != null))
                    {
                        __out.Append(__tmp138_line);
                        __tmp137_outputWritten = true;
                    }
                    if (!__tmp138_last || __tmp137_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp137_outputWritten)
            {
                __out.AppendLine(false); //255:325
            }
            if (Properties.GenerateMultipleFiles) //256:3
            {
                bool __tmp140_outputWritten = false;
                string __tmp141_line = "    public class "; //257:1
                if (!string.IsNullOrEmpty(__tmp141_line))
                {
                    __out.Append(__tmp141_line);
                    __tmp140_outputWritten = true;
                }
                StringBuilder __tmp142 = new StringBuilder();
                __tmp142.Append(Properties.LanguageClassName);
                using(StreamReader __tmp142Reader = new StreamReader(this.__ToStream(__tmp142.ToString())))
                {
                    bool __tmp142_last = __tmp142Reader.EndOfStream;
                    while(!__tmp142_last)
                    {
                        string __tmp142_line = __tmp142Reader.ReadLine();
                        __tmp142_last = __tmp142Reader.EndOfStream;
                        if ((__tmp142_last && !string.IsNullOrEmpty(__tmp142_line)) || (!__tmp142_last && __tmp142_line != null))
                        {
                            __out.Append(__tmp142_line);
                            __tmp140_outputWritten = true;
                        }
                        if (!__tmp142_last) __out.AppendLine(true);
                    }
                }
                string __tmp143_line = "GeneratorService : VsMultipleFileGenerator<object>"; //257:48
                if (!string.IsNullOrEmpty(__tmp143_line))
                {
                    __out.Append(__tmp143_line);
                    __tmp140_outputWritten = true;
                }
                if (__tmp140_outputWritten) __out.AppendLine(true);
                if (__tmp140_outputWritten)
                {
                    __out.AppendLine(false); //257:98
                }
                __out.Append("    {"); //258:1
                __out.AppendLine(false); //258:6
                __out.Append("        protected override MultipleFileGenerator<object> CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //259:1
                __out.AppendLine(false); //259:146
                __out.Append("		{"); //260:1
                __out.AppendLine(false); //260:4
                bool __tmp145_outputWritten = false;
                string __tmp146_line = "			// If there is a compile error in the following line, create a class "; //261:1
                if (!string.IsNullOrEmpty(__tmp146_line))
                {
                    __out.Append(__tmp146_line);
                    __tmp145_outputWritten = true;
                }
                StringBuilder __tmp147 = new StringBuilder();
                __tmp147.Append(Properties.LanguageClassName);
                using(StreamReader __tmp147Reader = new StreamReader(this.__ToStream(__tmp147.ToString())))
                {
                    bool __tmp147_last = __tmp147Reader.EndOfStream;
                    while(!__tmp147_last)
                    {
                        string __tmp147_line = __tmp147Reader.ReadLine();
                        __tmp147_last = __tmp147Reader.EndOfStream;
                        if ((__tmp147_last && !string.IsNullOrEmpty(__tmp147_line)) || (!__tmp147_last && __tmp147_line != null))
                        {
                            __out.Append(__tmp147_line);
                            __tmp145_outputWritten = true;
                        }
                        if (!__tmp147_last) __out.AppendLine(true);
                    }
                }
                string __tmp148_line = "Generator"; //261:103
                if (!string.IsNullOrEmpty(__tmp148_line))
                {
                    __out.Append(__tmp148_line);
                    __tmp145_outputWritten = true;
                }
                if (__tmp145_outputWritten) __out.AppendLine(true);
                if (__tmp145_outputWritten)
                {
                    __out.AppendLine(false); //261:112
                }
                __out.Append("			// which is a subclass of MultipleFileGenerator<object>"); //262:1
                __out.AppendLine(false); //262:59
                bool __tmp150_outputWritten = false;
                string __tmp151_line = "			return new "; //263:1
                if (!string.IsNullOrEmpty(__tmp151_line))
                {
                    __out.Append(__tmp151_line);
                    __tmp150_outputWritten = true;
                }
                StringBuilder __tmp152 = new StringBuilder();
                __tmp152.Append(Properties.LanguageClassName);
                using(StreamReader __tmp152Reader = new StreamReader(this.__ToStream(__tmp152.ToString())))
                {
                    bool __tmp152_last = __tmp152Reader.EndOfStream;
                    while(!__tmp152_last)
                    {
                        string __tmp152_line = __tmp152Reader.ReadLine();
                        __tmp152_last = __tmp152Reader.EndOfStream;
                        if ((__tmp152_last && !string.IsNullOrEmpty(__tmp152_line)) || (!__tmp152_last && __tmp152_line != null))
                        {
                            __out.Append(__tmp152_line);
                            __tmp150_outputWritten = true;
                        }
                        if (!__tmp152_last) __out.AppendLine(true);
                    }
                }
                string __tmp153_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //263:45
                if (!string.IsNullOrEmpty(__tmp153_line))
                {
                    __out.Append(__tmp153_line);
                    __tmp150_outputWritten = true;
                }
                if (__tmp150_outputWritten) __out.AppendLine(true);
                if (__tmp150_outputWritten)
                {
                    __out.AppendLine(false); //263:107
                }
                __out.Append("		}"); //264:1
                __out.AppendLine(false); //264:4
                __out.AppendLine(true); //265:1
                __out.Append("        public override string GetDefaultFileExtension()"); //266:1
                __out.AppendLine(false); //266:57
                __out.Append("        {"); //267:1
                __out.AppendLine(false); //267:10
                bool __tmp155_outputWritten = false;
                string __tmp156_line = "            return "; //268:1
                if (!string.IsNullOrEmpty(__tmp156_line))
                {
                    __out.Append(__tmp156_line);
                    __tmp155_outputWritten = true;
                }
                StringBuilder __tmp157 = new StringBuilder();
                __tmp157.Append(Properties.LanguageClassName);
                using(StreamReader __tmp157Reader = new StreamReader(this.__ToStream(__tmp157.ToString())))
                {
                    bool __tmp157_last = __tmp157Reader.EndOfStream;
                    while(!__tmp157_last)
                    {
                        string __tmp157_line = __tmp157Reader.ReadLine();
                        __tmp157_last = __tmp157Reader.EndOfStream;
                        if ((__tmp157_last && !string.IsNullOrEmpty(__tmp157_line)) || (!__tmp157_last && __tmp157_line != null))
                        {
                            __out.Append(__tmp157_line);
                            __tmp155_outputWritten = true;
                        }
                        if (!__tmp157_last) __out.AppendLine(true);
                    }
                }
                string __tmp158_line = "Generator.DefaultExtension;"; //268:50
                if (!string.IsNullOrEmpty(__tmp158_line))
                {
                    __out.Append(__tmp158_line);
                    __tmp155_outputWritten = true;
                }
                if (__tmp155_outputWritten) __out.AppendLine(true);
                if (__tmp155_outputWritten)
                {
                    __out.AppendLine(false); //268:77
                }
                __out.Append("        }"); //269:1
                __out.AppendLine(false); //269:10
                __out.Append("    }"); //270:1
                __out.AppendLine(false); //270:6
            }
            else //271:3
            {
                bool __tmp160_outputWritten = false;
                string __tmp161_line = "    public class "; //272:1
                if (!string.IsNullOrEmpty(__tmp161_line))
                {
                    __out.Append(__tmp161_line);
                    __tmp160_outputWritten = true;
                }
                StringBuilder __tmp162 = new StringBuilder();
                __tmp162.Append(Properties.LanguageClassName);
                using(StreamReader __tmp162Reader = new StreamReader(this.__ToStream(__tmp162.ToString())))
                {
                    bool __tmp162_last = __tmp162Reader.EndOfStream;
                    while(!__tmp162_last)
                    {
                        string __tmp162_line = __tmp162Reader.ReadLine();
                        __tmp162_last = __tmp162Reader.EndOfStream;
                        if ((__tmp162_last && !string.IsNullOrEmpty(__tmp162_line)) || (!__tmp162_last && __tmp162_line != null))
                        {
                            __out.Append(__tmp162_line);
                            __tmp160_outputWritten = true;
                        }
                        if (!__tmp162_last) __out.AppendLine(true);
                    }
                }
                string __tmp163_line = "GeneratorService : VsSingleFileGenerator"; //272:48
                if (!string.IsNullOrEmpty(__tmp163_line))
                {
                    __out.Append(__tmp163_line);
                    __tmp160_outputWritten = true;
                }
                if (__tmp160_outputWritten) __out.AppendLine(true);
                if (__tmp160_outputWritten)
                {
                    __out.AppendLine(false); //272:88
                }
                __out.Append("    {"); //273:1
                __out.AppendLine(false); //273:6
                __out.Append("        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)"); //274:1
                __out.AppendLine(false); //274:136
                __out.Append("		{"); //275:1
                __out.AppendLine(false); //275:4
                bool __tmp165_outputWritten = false;
                string __tmp166_line = "			// If there is a compile error in the following line, create a class "; //276:1
                if (!string.IsNullOrEmpty(__tmp166_line))
                {
                    __out.Append(__tmp166_line);
                    __tmp165_outputWritten = true;
                }
                StringBuilder __tmp167 = new StringBuilder();
                __tmp167.Append(Properties.LanguageClassName);
                using(StreamReader __tmp167Reader = new StreamReader(this.__ToStream(__tmp167.ToString())))
                {
                    bool __tmp167_last = __tmp167Reader.EndOfStream;
                    while(!__tmp167_last)
                    {
                        string __tmp167_line = __tmp167Reader.ReadLine();
                        __tmp167_last = __tmp167Reader.EndOfStream;
                        if ((__tmp167_last && !string.IsNullOrEmpty(__tmp167_line)) || (!__tmp167_last && __tmp167_line != null))
                        {
                            __out.Append(__tmp167_line);
                            __tmp165_outputWritten = true;
                        }
                        if (!__tmp167_last) __out.AppendLine(true);
                    }
                }
                string __tmp168_line = "Generator"; //276:103
                if (!string.IsNullOrEmpty(__tmp168_line))
                {
                    __out.Append(__tmp168_line);
                    __tmp165_outputWritten = true;
                }
                if (__tmp165_outputWritten) __out.AppendLine(true);
                if (__tmp165_outputWritten)
                {
                    __out.AppendLine(false); //276:112
                }
                __out.Append("			// which is a subclass of SingleFileGenerator"); //277:1
                __out.AppendLine(false); //277:49
                bool __tmp170_outputWritten = false;
                string __tmp171_line = "			return new "; //278:1
                if (!string.IsNullOrEmpty(__tmp171_line))
                {
                    __out.Append(__tmp171_line);
                    __tmp170_outputWritten = true;
                }
                StringBuilder __tmp172 = new StringBuilder();
                __tmp172.Append(Properties.LanguageClassName);
                using(StreamReader __tmp172Reader = new StreamReader(this.__ToStream(__tmp172.ToString())))
                {
                    bool __tmp172_last = __tmp172Reader.EndOfStream;
                    while(!__tmp172_last)
                    {
                        string __tmp172_line = __tmp172Reader.ReadLine();
                        __tmp172_last = __tmp172Reader.EndOfStream;
                        if ((__tmp172_last && !string.IsNullOrEmpty(__tmp172_line)) || (!__tmp172_last && __tmp172_line != null))
                        {
                            __out.Append(__tmp172_line);
                            __tmp170_outputWritten = true;
                        }
                        if (!__tmp172_last) __out.AppendLine(true);
                    }
                }
                string __tmp173_line = "Generator(inputFilePath, inputFileContents, defaultNamespace);"; //278:45
                if (!string.IsNullOrEmpty(__tmp173_line))
                {
                    __out.Append(__tmp173_line);
                    __tmp170_outputWritten = true;
                }
                if (__tmp170_outputWritten) __out.AppendLine(true);
                if (__tmp170_outputWritten)
                {
                    __out.AppendLine(false); //278:107
                }
                __out.Append("		}"); //279:1
                __out.AppendLine(false); //279:4
                __out.AppendLine(true); //280:1
                __out.Append("        public override string GetDefaultFileExtension()"); //281:1
                __out.AppendLine(false); //281:57
                __out.Append("        {"); //282:1
                __out.AppendLine(false); //282:10
                bool __tmp175_outputWritten = false;
                string __tmp176_line = "            return "; //283:1
                if (!string.IsNullOrEmpty(__tmp176_line))
                {
                    __out.Append(__tmp176_line);
                    __tmp175_outputWritten = true;
                }
                StringBuilder __tmp177 = new StringBuilder();
                __tmp177.Append(Properties.LanguageClassName);
                using(StreamReader __tmp177Reader = new StreamReader(this.__ToStream(__tmp177.ToString())))
                {
                    bool __tmp177_last = __tmp177Reader.EndOfStream;
                    while(!__tmp177_last)
                    {
                        string __tmp177_line = __tmp177Reader.ReadLine();
                        __tmp177_last = __tmp177Reader.EndOfStream;
                        if ((__tmp177_last && !string.IsNullOrEmpty(__tmp177_line)) || (!__tmp177_last && __tmp177_line != null))
                        {
                            __out.Append(__tmp177_line);
                            __tmp175_outputWritten = true;
                        }
                        if (!__tmp177_last) __out.AppendLine(true);
                    }
                }
                string __tmp178_line = "Generator.DefaultExtension;"; //283:50
                if (!string.IsNullOrEmpty(__tmp178_line))
                {
                    __out.Append(__tmp178_line);
                    __tmp175_outputWritten = true;
                }
                if (__tmp175_outputWritten) __out.AppendLine(true);
                if (__tmp175_outputWritten)
                {
                    __out.AppendLine(false); //283:77
                }
                __out.Append("        }"); //284:1
                __out.AppendLine(false); //284:10
                __out.Append("    }"); //285:1
                __out.AppendLine(false); //285:6
            }
            bool __tmp180_outputWritten = false;
            string __tmp181_line = "    public class "; //287:1
            if (!string.IsNullOrEmpty(__tmp181_line))
            {
                __out.Append(__tmp181_line);
                __tmp180_outputWritten = true;
            }
            StringBuilder __tmp182 = new StringBuilder();
            __tmp182.Append(Properties.LanguageClassName);
            using(StreamReader __tmp182Reader = new StreamReader(this.__ToStream(__tmp182.ToString())))
            {
                bool __tmp182_last = __tmp182Reader.EndOfStream;
                while(!__tmp182_last)
                {
                    string __tmp182_line = __tmp182Reader.ReadLine();
                    __tmp182_last = __tmp182Reader.EndOfStream;
                    if ((__tmp182_last && !string.IsNullOrEmpty(__tmp182_line)) || (!__tmp182_last && __tmp182_line != null))
                    {
                        __out.Append(__tmp182_line);
                        __tmp180_outputWritten = true;
                    }
                    if (!__tmp182_last) __out.AppendLine(true);
                }
            }
            string __tmp183_line = "LanguageScanner : IScanner"; //287:48
            if (!string.IsNullOrEmpty(__tmp183_line))
            {
                __out.Append(__tmp183_line);
                __tmp180_outputWritten = true;
            }
            if (__tmp180_outputWritten) __out.AppendLine(true);
            if (__tmp180_outputWritten)
            {
                __out.AppendLine(false); //287:74
            }
            __out.Append("    {"); //288:1
            __out.AppendLine(false); //288:6
            __out.Append("        private int currentOffset;"); //289:1
            __out.AppendLine(false); //289:35
            __out.Append("        private string currentLine;"); //290:1
            __out.AppendLine(false); //290:36
            bool __tmp185_outputWritten = false;
            string __tmp186_line = "        private "; //291:1
            if (!string.IsNullOrEmpty(__tmp186_line))
            {
                __out.Append(__tmp186_line);
                __tmp185_outputWritten = true;
            }
            StringBuilder __tmp187 = new StringBuilder();
            __tmp187.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp187Reader = new StreamReader(this.__ToStream(__tmp187.ToString())))
            {
                bool __tmp187_last = __tmp187Reader.EndOfStream;
                while(!__tmp187_last)
                {
                    string __tmp187_line = __tmp187Reader.ReadLine();
                    __tmp187_last = __tmp187Reader.EndOfStream;
                    if ((__tmp187_last && !string.IsNullOrEmpty(__tmp187_line)) || (!__tmp187_last && __tmp187_line != null))
                    {
                        __out.Append(__tmp187_line);
                        __tmp185_outputWritten = true;
                    }
                    if (!__tmp187_last) __out.AppendLine(true);
                }
            }
            string __tmp188_line = ".Syntax.InternalSyntax."; //291:47
            if (!string.IsNullOrEmpty(__tmp188_line))
            {
                __out.Append(__tmp188_line);
                __tmp185_outputWritten = true;
            }
            StringBuilder __tmp189 = new StringBuilder();
            __tmp189.Append(Properties.LanguageClassName);
            using(StreamReader __tmp189Reader = new StreamReader(this.__ToStream(__tmp189.ToString())))
            {
                bool __tmp189_last = __tmp189Reader.EndOfStream;
                while(!__tmp189_last)
                {
                    string __tmp189_line = __tmp189Reader.ReadLine();
                    __tmp189_last = __tmp189Reader.EndOfStream;
                    if ((__tmp189_last && !string.IsNullOrEmpty(__tmp189_line)) || (!__tmp189_last && __tmp189_line != null))
                    {
                        __out.Append(__tmp189_line);
                        __tmp185_outputWritten = true;
                    }
                    if (!__tmp189_last) __out.AppendLine(true);
                }
            }
            string __tmp190_line = "Lexer lexer;"; //291:100
            if (!string.IsNullOrEmpty(__tmp190_line))
            {
                __out.Append(__tmp190_line);
                __tmp185_outputWritten = true;
            }
            if (__tmp185_outputWritten) __out.AppendLine(true);
            if (__tmp185_outputWritten)
            {
                __out.AppendLine(false); //291:112
            }
            bool __tmp192_outputWritten = false;
            string __tmp193_line = "        private "; //292:1
            if (!string.IsNullOrEmpty(__tmp193_line))
            {
                __out.Append(__tmp193_line);
                __tmp192_outputWritten = true;
            }
            StringBuilder __tmp194 = new StringBuilder();
            __tmp194.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp194Reader = new StreamReader(this.__ToStream(__tmp194.ToString())))
            {
                bool __tmp194_last = __tmp194Reader.EndOfStream;
                while(!__tmp194_last)
                {
                    string __tmp194_line = __tmp194Reader.ReadLine();
                    __tmp194_last = __tmp194Reader.EndOfStream;
                    if ((__tmp194_last && !string.IsNullOrEmpty(__tmp194_line)) || (!__tmp194_last && __tmp194_line != null))
                    {
                        __out.Append(__tmp194_line);
                        __tmp192_outputWritten = true;
                    }
                    if (!__tmp194_last) __out.AppendLine(true);
                }
            }
            string __tmp195_line = ".Syntax."; //292:47
            if (!string.IsNullOrEmpty(__tmp195_line))
            {
                __out.Append(__tmp195_line);
                __tmp192_outputWritten = true;
            }
            StringBuilder __tmp196 = new StringBuilder();
            __tmp196.Append(Properties.LanguageClassName);
            using(StreamReader __tmp196Reader = new StreamReader(this.__ToStream(__tmp196.ToString())))
            {
                bool __tmp196_last = __tmp196Reader.EndOfStream;
                while(!__tmp196_last)
                {
                    string __tmp196_line = __tmp196Reader.ReadLine();
                    __tmp196_last = __tmp196Reader.EndOfStream;
                    if ((__tmp196_last && !string.IsNullOrEmpty(__tmp196_line)) || (!__tmp196_last && __tmp196_line != null))
                    {
                        __out.Append(__tmp196_line);
                        __tmp192_outputWritten = true;
                    }
                    if (!__tmp196_last) __out.AppendLine(true);
                }
            }
            string __tmp197_line = "SyntaxFacts syntaxFacts;"; //292:85
            if (!string.IsNullOrEmpty(__tmp197_line))
            {
                __out.Append(__tmp197_line);
                __tmp192_outputWritten = true;
            }
            if (__tmp192_outputWritten) __out.AppendLine(true);
            if (__tmp192_outputWritten)
            {
                __out.AppendLine(false); //292:109
            }
            __out.Append("        private Dictionary<LanguageScannerState, int> inverseStates;"); //293:1
            __out.AppendLine(false); //293:69
            __out.Append("        private Dictionary<int, LanguageScannerState> states;"); //294:1
            __out.AppendLine(false); //294:62
            __out.Append("        private int lastState;"); //295:1
            __out.AppendLine(false); //295:31
            bool __tmp199_outputWritten = false;
            string __tmp200_line = "        public "; //296:1
            if (!string.IsNullOrEmpty(__tmp200_line))
            {
                __out.Append(__tmp200_line);
                __tmp199_outputWritten = true;
            }
            StringBuilder __tmp201 = new StringBuilder();
            __tmp201.Append(Properties.LanguageClassName);
            using(StreamReader __tmp201Reader = new StreamReader(this.__ToStream(__tmp201.ToString())))
            {
                bool __tmp201_last = __tmp201Reader.EndOfStream;
                while(!__tmp201_last)
                {
                    string __tmp201_line = __tmp201Reader.ReadLine();
                    __tmp201_last = __tmp201Reader.EndOfStream;
                    if ((__tmp201_last && !string.IsNullOrEmpty(__tmp201_line)) || (!__tmp201_last && __tmp201_line != null))
                    {
                        __out.Append(__tmp201_line);
                        __tmp199_outputWritten = true;
                    }
                    if (!__tmp201_last) __out.AppendLine(true);
                }
            }
            string __tmp202_line = "LanguageScanner()"; //296:46
            if (!string.IsNullOrEmpty(__tmp202_line))
            {
                __out.Append(__tmp202_line);
                __tmp199_outputWritten = true;
            }
            if (__tmp199_outputWritten) __out.AppendLine(true);
            if (__tmp199_outputWritten)
            {
                __out.AppendLine(false); //296:63
            }
            __out.Append("        {"); //297:1
            __out.AppendLine(false); //297:10
            __out.Append("            this.inverseStates = new Dictionary<LanguageScannerState, int>();"); //298:1
            __out.AppendLine(false); //298:78
            __out.Append("            this.states = new Dictionary<int, LanguageScannerState>();"); //299:1
            __out.AppendLine(false); //299:71
            __out.Append("            this.lastState = 0;"); //300:1
            __out.AppendLine(false); //300:32
            bool __tmp204_outputWritten = false;
            string __tmp205_line = "            this.syntaxFacts = "; //301:1
            if (!string.IsNullOrEmpty(__tmp205_line))
            {
                __out.Append(__tmp205_line);
                __tmp204_outputWritten = true;
            }
            StringBuilder __tmp206 = new StringBuilder();
            __tmp206.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp206Reader = new StreamReader(this.__ToStream(__tmp206.ToString())))
            {
                bool __tmp206_last = __tmp206Reader.EndOfStream;
                while(!__tmp206_last)
                {
                    string __tmp206_line = __tmp206Reader.ReadLine();
                    __tmp206_last = __tmp206Reader.EndOfStream;
                    if ((__tmp206_last && !string.IsNullOrEmpty(__tmp206_line)) || (!__tmp206_last && __tmp206_line != null))
                    {
                        __out.Append(__tmp206_line);
                        __tmp204_outputWritten = true;
                    }
                    if (!__tmp206_last) __out.AppendLine(true);
                }
            }
            string __tmp207_line = ".Syntax."; //301:62
            if (!string.IsNullOrEmpty(__tmp207_line))
            {
                __out.Append(__tmp207_line);
                __tmp204_outputWritten = true;
            }
            StringBuilder __tmp208 = new StringBuilder();
            __tmp208.Append(Properties.LanguageClassName);
            using(StreamReader __tmp208Reader = new StreamReader(this.__ToStream(__tmp208.ToString())))
            {
                bool __tmp208_last = __tmp208Reader.EndOfStream;
                while(!__tmp208_last)
                {
                    string __tmp208_line = __tmp208Reader.ReadLine();
                    __tmp208_last = __tmp208Reader.EndOfStream;
                    if ((__tmp208_last && !string.IsNullOrEmpty(__tmp208_line)) || (!__tmp208_last && __tmp208_line != null))
                    {
                        __out.Append(__tmp208_line);
                        __tmp204_outputWritten = true;
                    }
                    if (!__tmp208_last) __out.AppendLine(true);
                }
            }
            string __tmp209_line = "SyntaxFacts.Instance;"; //301:100
            if (!string.IsNullOrEmpty(__tmp209_line))
            {
                __out.Append(__tmp209_line);
                __tmp204_outputWritten = true;
            }
            if (__tmp204_outputWritten) __out.AppendLine(true);
            if (__tmp204_outputWritten)
            {
                __out.AppendLine(false); //301:121
            }
            __out.Append("        }"); //302:1
            __out.AppendLine(false); //302:10
            bool __tmp211_outputWritten = false;
            string __tmp212_line = "        private void LoadState(int state, "; //303:1
            if (!string.IsNullOrEmpty(__tmp212_line))
            {
                __out.Append(__tmp212_line);
                __tmp211_outputWritten = true;
            }
            StringBuilder __tmp213 = new StringBuilder();
            __tmp213.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp213Reader = new StreamReader(this.__ToStream(__tmp213.ToString())))
            {
                bool __tmp213_last = __tmp213Reader.EndOfStream;
                while(!__tmp213_last)
                {
                    string __tmp213_line = __tmp213Reader.ReadLine();
                    __tmp213_last = __tmp213Reader.EndOfStream;
                    if ((__tmp213_last && !string.IsNullOrEmpty(__tmp213_line)) || (!__tmp213_last && __tmp213_line != null))
                    {
                        __out.Append(__tmp213_line);
                        __tmp211_outputWritten = true;
                    }
                    if (!__tmp213_last) __out.AppendLine(true);
                }
            }
            string __tmp214_line = ".Syntax.InternalSyntax."; //303:73
            if (!string.IsNullOrEmpty(__tmp214_line))
            {
                __out.Append(__tmp214_line);
                __tmp211_outputWritten = true;
            }
            StringBuilder __tmp215 = new StringBuilder();
            __tmp215.Append(Properties.LanguageClassName);
            using(StreamReader __tmp215Reader = new StreamReader(this.__ToStream(__tmp215.ToString())))
            {
                bool __tmp215_last = __tmp215Reader.EndOfStream;
                while(!__tmp215_last)
                {
                    string __tmp215_line = __tmp215Reader.ReadLine();
                    __tmp215_last = __tmp215Reader.EndOfStream;
                    if ((__tmp215_last && !string.IsNullOrEmpty(__tmp215_line)) || (!__tmp215_last && __tmp215_line != null))
                    {
                        __out.Append(__tmp215_line);
                        __tmp211_outputWritten = true;
                    }
                    if (!__tmp215_last) __out.AppendLine(true);
                }
            }
            string __tmp216_line = "Lexer lexer)"; //303:126
            if (!string.IsNullOrEmpty(__tmp216_line))
            {
                __out.Append(__tmp216_line);
                __tmp211_outputWritten = true;
            }
            if (__tmp211_outputWritten) __out.AppendLine(true);
            if (__tmp211_outputWritten)
            {
                __out.AppendLine(false); //303:138
            }
            __out.Append("        {"); //304:1
            __out.AppendLine(false); //304:10
            __out.Append("            LanguageScannerState value = default(LanguageScannerState);"); //305:1
            __out.AppendLine(false); //305:72
            __out.Append("            this.states.TryGetValue(state, out value);"); //306:1
            __out.AppendLine(false); //306:55
            __out.Append("            value.Restore(lexer);"); //307:1
            __out.AppendLine(false); //307:34
            __out.Append("        }"); //308:1
            __out.AppendLine(false); //308:10
            bool __tmp218_outputWritten = false;
            string __tmp219_line = "        private int SaveState("; //309:1
            if (!string.IsNullOrEmpty(__tmp219_line))
            {
                __out.Append(__tmp219_line);
                __tmp218_outputWritten = true;
            }
            StringBuilder __tmp220 = new StringBuilder();
            __tmp220.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp220Reader = new StreamReader(this.__ToStream(__tmp220.ToString())))
            {
                bool __tmp220_last = __tmp220Reader.EndOfStream;
                while(!__tmp220_last)
                {
                    string __tmp220_line = __tmp220Reader.ReadLine();
                    __tmp220_last = __tmp220Reader.EndOfStream;
                    if ((__tmp220_last && !string.IsNullOrEmpty(__tmp220_line)) || (!__tmp220_last && __tmp220_line != null))
                    {
                        __out.Append(__tmp220_line);
                        __tmp218_outputWritten = true;
                    }
                    if (!__tmp220_last) __out.AppendLine(true);
                }
            }
            string __tmp221_line = ".Syntax.InternalSyntax."; //309:61
            if (!string.IsNullOrEmpty(__tmp221_line))
            {
                __out.Append(__tmp221_line);
                __tmp218_outputWritten = true;
            }
            StringBuilder __tmp222 = new StringBuilder();
            __tmp222.Append(Properties.LanguageClassName);
            using(StreamReader __tmp222Reader = new StreamReader(this.__ToStream(__tmp222.ToString())))
            {
                bool __tmp222_last = __tmp222Reader.EndOfStream;
                while(!__tmp222_last)
                {
                    string __tmp222_line = __tmp222Reader.ReadLine();
                    __tmp222_last = __tmp222Reader.EndOfStream;
                    if ((__tmp222_last && !string.IsNullOrEmpty(__tmp222_line)) || (!__tmp222_last && __tmp222_line != null))
                    {
                        __out.Append(__tmp222_line);
                        __tmp218_outputWritten = true;
                    }
                    if (!__tmp222_last) __out.AppendLine(true);
                }
            }
            string __tmp223_line = "Lexer lexer)"; //309:114
            if (!string.IsNullOrEmpty(__tmp223_line))
            {
                __out.Append(__tmp223_line);
                __tmp218_outputWritten = true;
            }
            if (__tmp218_outputWritten) __out.AppendLine(true);
            if (__tmp218_outputWritten)
            {
                __out.AppendLine(false); //309:126
            }
            __out.Append("        {"); //310:1
            __out.AppendLine(false); //310:10
            __out.Append("            int result = 0;"); //311:1
            __out.AppendLine(false); //311:28
            __out.Append("            LanguageScannerState state = new LanguageScannerState(lexer);"); //312:1
            __out.AppendLine(false); //312:74
            __out.Append("            if (!this.inverseStates.TryGetValue(state, out result))"); //313:1
            __out.AppendLine(false); //313:68
            __out.Append("            {"); //314:1
            __out.AppendLine(false); //314:14
            __out.Append("                result = ++lastState;"); //315:1
            __out.AppendLine(false); //315:38
            __out.Append("                this.states.Add(result, state);"); //316:1
            __out.AppendLine(false); //316:48
            __out.Append("                this.inverseStates.Add(state, result);"); //317:1
            __out.AppendLine(false); //317:55
            __out.Append("            }"); //318:1
            __out.AppendLine(false); //318:14
            __out.Append("            return result;"); //319:1
            __out.AppendLine(false); //319:27
            __out.Append("        }"); //320:1
            __out.AppendLine(false); //320:10
            __out.Append("        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)"); //321:1
            __out.AppendLine(false); //321:87
            __out.Append("        {"); //322:1
            __out.AppendLine(false); //322:10
            __out.Append("            try"); //323:1
            __out.AppendLine(false); //323:16
            __out.Append("            {"); //324:1
            __out.AppendLine(false); //324:14
            __out.Append("                if (this.lexer == null)"); //325:1
            __out.AppendLine(false); //325:40
            __out.Append("                {"); //326:1
            __out.AppendLine(false); //326:18
            bool __tmp225_outputWritten = false;
            string __tmp226_line = "                    this.lexer = new "; //327:1
            if (!string.IsNullOrEmpty(__tmp226_line))
            {
                __out.Append(__tmp226_line);
                __tmp225_outputWritten = true;
            }
            StringBuilder __tmp227 = new StringBuilder();
            __tmp227.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp227Reader = new StreamReader(this.__ToStream(__tmp227.ToString())))
            {
                bool __tmp227_last = __tmp227Reader.EndOfStream;
                while(!__tmp227_last)
                {
                    string __tmp227_line = __tmp227Reader.ReadLine();
                    __tmp227_last = __tmp227Reader.EndOfStream;
                    if ((__tmp227_last && !string.IsNullOrEmpty(__tmp227_line)) || (!__tmp227_last && __tmp227_line != null))
                    {
                        __out.Append(__tmp227_line);
                        __tmp225_outputWritten = true;
                    }
                    if (!__tmp227_last) __out.AppendLine(true);
                }
            }
            string __tmp228_line = ".Syntax.InternalSyntax."; //327:68
            if (!string.IsNullOrEmpty(__tmp228_line))
            {
                __out.Append(__tmp228_line);
                __tmp225_outputWritten = true;
            }
            StringBuilder __tmp229 = new StringBuilder();
            __tmp229.Append(Properties.LanguageClassName);
            using(StreamReader __tmp229Reader = new StreamReader(this.__ToStream(__tmp229.ToString())))
            {
                bool __tmp229_last = __tmp229Reader.EndOfStream;
                while(!__tmp229_last)
                {
                    string __tmp229_line = __tmp229Reader.ReadLine();
                    __tmp229_last = __tmp229Reader.EndOfStream;
                    if ((__tmp229_last && !string.IsNullOrEmpty(__tmp229_line)) || (!__tmp229_last && __tmp229_line != null))
                    {
                        __out.Append(__tmp229_line);
                        __tmp225_outputWritten = true;
                    }
                    if (!__tmp229_last) __out.AppendLine(true);
                }
            }
            string __tmp230_line = "Lexer(new AntlrInputStream(this.currentLine + \""; //327:121
            if (!string.IsNullOrEmpty(__tmp230_line))
            {
                __out.Append(__tmp230_line);
                __tmp225_outputWritten = true;
            }
            string __tmp231_line = "\\"; //327:168
            if (!string.IsNullOrEmpty(__tmp231_line))
            {
                __out.Append(__tmp231_line);
                __tmp225_outputWritten = true;
            }
            string __tmp232_line = "r"; //327:169
            if (!string.IsNullOrEmpty(__tmp232_line))
            {
                __out.Append(__tmp232_line);
                __tmp225_outputWritten = true;
            }
            string __tmp233_line = "\\"; //327:170
            if (!string.IsNullOrEmpty(__tmp233_line))
            {
                __out.Append(__tmp233_line);
                __tmp225_outputWritten = true;
            }
            string __tmp234_line = "n\"));"; //327:171
            if (!string.IsNullOrEmpty(__tmp234_line))
            {
                __out.Append(__tmp234_line);
                __tmp225_outputWritten = true;
            }
            if (__tmp225_outputWritten) __out.AppendLine(true);
            if (__tmp225_outputWritten)
            {
                __out.AppendLine(false); //327:176
            }
            __out.Append("                }"); //328:1
            __out.AppendLine(false); //328:18
            __out.Append("                this.LoadState(state, this.lexer);"); //329:1
            __out.AppendLine(false); //329:51
            __out.Append("                IToken token = this.lexer.NextToken();"); //330:1
            __out.AppendLine(false); //330:55
            __out.Append("                int tokenType = (int)this.syntaxFacts.GetTokenKind(token.Type);"); //331:1
            __out.AppendLine(false); //331:80
            __out.Append("                if (tokenType == 0)"); //332:1
            __out.AppendLine(false); //332:36
            __out.Append("                {"); //333:1
            __out.AppendLine(false); //333:18
            __out.Append("                    tokenType = (int)this.syntaxFacts.GetModeTokenKind(this.lexer.CurrentMode);"); //334:1
            __out.AppendLine(false); //334:96
            __out.Append("                }"); //335:1
            __out.AppendLine(false); //335:18
            bool __tmp236_outputWritten = false;
            string __tmp237_line = "                if (tokenType >= 0 && tokenType < "; //336:1
            if (!string.IsNullOrEmpty(__tmp237_line))
            {
                __out.Append(__tmp237_line);
                __tmp236_outputWritten = true;
            }
            StringBuilder __tmp238 = new StringBuilder();
            __tmp238.Append(Properties.LanguageClassName);
            using(StreamReader __tmp238Reader = new StreamReader(this.__ToStream(__tmp238.ToString())))
            {
                bool __tmp238_last = __tmp238Reader.EndOfStream;
                while(!__tmp238_last)
                {
                    string __tmp238_line = __tmp238Reader.ReadLine();
                    __tmp238_last = __tmp238Reader.EndOfStream;
                    if ((__tmp238_last && !string.IsNullOrEmpty(__tmp238_line)) || (!__tmp238_last && __tmp238_line != null))
                    {
                        __out.Append(__tmp238_line);
                        __tmp236_outputWritten = true;
                    }
                    if (!__tmp238_last) __out.AppendLine(true);
                }
            }
            string __tmp239_line = "LanguageConfig.Instance.ColorableItems.Count)"; //336:81
            if (!string.IsNullOrEmpty(__tmp239_line))
            {
                __out.Append(__tmp239_line);
                __tmp236_outputWritten = true;
            }
            if (__tmp236_outputWritten) __out.AppendLine(true);
            if (__tmp236_outputWritten)
            {
                __out.AppendLine(false); //336:126
            }
            __out.Append("                {"); //337:1
            __out.AppendLine(false); //337:18
            bool __tmp241_outputWritten = false;
            string __tmp240Prefix = "                    "; //338:1
            StringBuilder __tmp242 = new StringBuilder();
            __tmp242.Append(Properties.LanguageClassName);
            using(StreamReader __tmp242Reader = new StreamReader(this.__ToStream(__tmp242.ToString())))
            {
                bool __tmp242_last = __tmp242Reader.EndOfStream;
                while(!__tmp242_last)
                {
                    string __tmp242_line = __tmp242Reader.ReadLine();
                    __tmp242_last = __tmp242Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp240Prefix))
                    {
                        __out.Append(__tmp240Prefix);
                        __tmp241_outputWritten = true;
                    }
                    if ((__tmp242_last && !string.IsNullOrEmpty(__tmp242_line)) || (!__tmp242_last && __tmp242_line != null))
                    {
                        __out.Append(__tmp242_line);
                        __tmp241_outputWritten = true;
                    }
                    if (!__tmp242_last) __out.AppendLine(true);
                }
            }
            string __tmp243_line = "LanguageColorableItem colorItem = "; //338:51
            if (!string.IsNullOrEmpty(__tmp243_line))
            {
                __out.Append(__tmp243_line);
                __tmp241_outputWritten = true;
            }
            StringBuilder __tmp244 = new StringBuilder();
            __tmp244.Append(Properties.LanguageClassName);
            using(StreamReader __tmp244Reader = new StreamReader(this.__ToStream(__tmp244.ToString())))
            {
                bool __tmp244_last = __tmp244Reader.EndOfStream;
                while(!__tmp244_last)
                {
                    string __tmp244_line = __tmp244Reader.ReadLine();
                    __tmp244_last = __tmp244Reader.EndOfStream;
                    if ((__tmp244_last && !string.IsNullOrEmpty(__tmp244_line)) || (!__tmp244_last && __tmp244_line != null))
                    {
                        __out.Append(__tmp244_line);
                        __tmp241_outputWritten = true;
                    }
                    if (!__tmp244_last) __out.AppendLine(true);
                }
            }
            string __tmp245_line = "LanguageConfig.Instance.ColorableItems"; //338:115
            if (!string.IsNullOrEmpty(__tmp245_line))
            {
                __out.Append(__tmp245_line);
                __tmp241_outputWritten = true;
            }
            StringBuilder __tmp246 = new StringBuilder();
            __tmp246.Append("[tokenType]");
            using(StreamReader __tmp246Reader = new StreamReader(this.__ToStream(__tmp246.ToString())))
            {
                bool __tmp246_last = __tmp246Reader.EndOfStream;
                while(!__tmp246_last)
                {
                    string __tmp246_line = __tmp246Reader.ReadLine();
                    __tmp246_last = __tmp246Reader.EndOfStream;
                    if ((__tmp246_last && !string.IsNullOrEmpty(__tmp246_line)) || (!__tmp246_last && __tmp246_line != null))
                    {
                        __out.Append(__tmp246_line);
                        __tmp241_outputWritten = true;
                    }
                    if (!__tmp246_last) __out.AppendLine(true);
                }
            }
            string __tmp247_line = ";"; //338:168
            if (!string.IsNullOrEmpty(__tmp247_line))
            {
                __out.Append(__tmp247_line);
                __tmp241_outputWritten = true;
            }
            if (__tmp241_outputWritten) __out.AppendLine(true);
            if (__tmp241_outputWritten)
            {
                __out.AppendLine(false); //338:169
            }
            __out.Append("                    tokenInfo.Token = token.Type;"); //339:1
            __out.AppendLine(false); //339:50
            __out.Append("                    tokenInfo.Type = colorItem.TokenType;"); //340:1
            __out.AppendLine(false); //340:58
            __out.Append("                    tokenInfo.Color = (TokenColor)tokenType;"); //341:1
            __out.AppendLine(false); //341:61
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //342:1
            __out.AppendLine(false); //342:60
            __out.Append("                }"); //343:1
            __out.AppendLine(false); //343:18
            __out.Append("                else"); //344:1
            __out.AppendLine(false); //344:21
            __out.Append("                {"); //345:1
            __out.AppendLine(false); //345:18
            __out.Append("                    tokenInfo.Token = token.Type;"); //346:1
            __out.AppendLine(false); //346:50
            __out.Append("                    tokenInfo.Type = TokenType.Text;"); //347:1
            __out.AppendLine(false); //347:53
            __out.Append("                    tokenInfo.Color = TokenColor.Text;"); //348:1
            __out.AppendLine(false); //348:55
            __out.Append("                    tokenInfo.Trigger = TokenTriggers.None;"); //349:1
            __out.AppendLine(false); //349:60
            __out.Append("                }"); //350:1
            __out.AppendLine(false); //350:18
            __out.Append("                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)"); //351:1
            __out.AppendLine(false); //351:103
            __out.Append("                {"); //352:1
            __out.AppendLine(false); //352:18
            __out.Append("                    return false;"); //353:1
            __out.AppendLine(false); //353:34
            __out.Append("                }"); //354:1
            __out.AppendLine(false); //354:18
            __out.Append("                tokenInfo.StartIndex = this.currentOffset;"); //355:1
            __out.AppendLine(false); //355:59
            __out.Append("                this.currentOffset += token.Text.Length;"); //356:1
            __out.AppendLine(false); //356:57
            __out.Append("                tokenInfo.EndIndex = this.currentOffset - 1;"); //357:1
            __out.AppendLine(false); //357:61
            __out.Append("                state = this.SaveState(lexer);"); //358:1
            __out.AppendLine(false); //358:47
            __out.Append("                return true;"); //359:1
            __out.AppendLine(false); //359:29
            __out.Append("            }"); //360:1
            __out.AppendLine(false); //360:14
            __out.Append("            catch (Exception)"); //361:1
            __out.AppendLine(false); //361:30
            __out.Append("            {"); //362:1
            __out.AppendLine(false); //362:14
            __out.Append("                return false;"); //363:1
            __out.AppendLine(false); //363:30
            __out.Append("            }"); //364:1
            __out.AppendLine(false); //364:14
            __out.Append("        }"); //365:1
            __out.AppendLine(false); //365:10
            __out.Append("        public void SetSource(string source, int offset)"); //366:1
            __out.AppendLine(false); //366:57
            __out.Append("        {"); //367:1
            __out.AppendLine(false); //367:10
            __out.Append("            //if (this.currentOffset != offset || this.currentLine != source)"); //368:1
            __out.AppendLine(false); //368:78
            __out.Append("            {"); //369:1
            __out.AppendLine(false); //369:14
            __out.Append("                this.currentOffset = offset;"); //370:1
            __out.AppendLine(false); //370:45
            __out.Append("                this.currentLine = source;"); //371:1
            __out.AppendLine(false); //371:43
            __out.Append("                this.lexer = null;"); //372:1
            __out.AppendLine(false); //372:35
            __out.Append("            }"); //373:1
            __out.AppendLine(false); //373:14
            __out.Append("        }"); //374:1
            __out.AppendLine(false); //374:10
            __out.Append("        internal void ScanLine(ref int state)"); //375:1
            __out.AppendLine(false); //375:46
            __out.Append("        {"); //376:1
            __out.AppendLine(false); //376:10
            __out.Append("            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;"); //377:1
            __out.AppendLine(false); //377:86
            __out.Append("        }"); //378:1
            __out.AppendLine(false); //378:10
            __out.Append("        internal struct LanguageScannerState"); //379:1
            __out.AppendLine(false); //379:45
            __out.Append("        {"); //380:1
            __out.AppendLine(false); //380:10
            bool __tmp249_outputWritten = false;
            string __tmp250_line = "            public LanguageScannerState("; //381:1
            if (!string.IsNullOrEmpty(__tmp250_line))
            {
                __out.Append(__tmp250_line);
                __tmp249_outputWritten = true;
            }
            StringBuilder __tmp251 = new StringBuilder();
            __tmp251.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp251Reader = new StreamReader(this.__ToStream(__tmp251.ToString())))
            {
                bool __tmp251_last = __tmp251Reader.EndOfStream;
                while(!__tmp251_last)
                {
                    string __tmp251_line = __tmp251Reader.ReadLine();
                    __tmp251_last = __tmp251Reader.EndOfStream;
                    if ((__tmp251_last && !string.IsNullOrEmpty(__tmp251_line)) || (!__tmp251_last && __tmp251_line != null))
                    {
                        __out.Append(__tmp251_line);
                        __tmp249_outputWritten = true;
                    }
                    if (!__tmp251_last) __out.AppendLine(true);
                }
            }
            string __tmp252_line = ".Syntax.InternalSyntax."; //381:71
            if (!string.IsNullOrEmpty(__tmp252_line))
            {
                __out.Append(__tmp252_line);
                __tmp249_outputWritten = true;
            }
            StringBuilder __tmp253 = new StringBuilder();
            __tmp253.Append(Properties.LanguageClassName);
            using(StreamReader __tmp253Reader = new StreamReader(this.__ToStream(__tmp253.ToString())))
            {
                bool __tmp253_last = __tmp253Reader.EndOfStream;
                while(!__tmp253_last)
                {
                    string __tmp253_line = __tmp253Reader.ReadLine();
                    __tmp253_last = __tmp253Reader.EndOfStream;
                    if ((__tmp253_last && !string.IsNullOrEmpty(__tmp253_line)) || (!__tmp253_last && __tmp253_line != null))
                    {
                        __out.Append(__tmp253_line);
                        __tmp249_outputWritten = true;
                    }
                    if (!__tmp253_last) __out.AppendLine(true);
                }
            }
            string __tmp254_line = "Lexer lexer)"; //381:124
            if (!string.IsNullOrEmpty(__tmp254_line))
            {
                __out.Append(__tmp254_line);
                __tmp249_outputWritten = true;
            }
            if (__tmp249_outputWritten) __out.AppendLine(true);
            if (__tmp249_outputWritten)
            {
                __out.AppendLine(false); //381:136
            }
            __out.Append("            {"); //382:1
            __out.AppendLine(false); //382:14
            __out.Append("                this._mode = lexer.CurrentMode;"); //383:1
            __out.AppendLine(false); //383:48
            __out.Append("                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;"); //384:1
            __out.AppendLine(false); //384:101
            __out.Append("                this._type = lexer.Type;"); //385:1
            __out.AppendLine(false); //385:41
            __out.Append("                this._channel = lexer.Channel;"); //386:1
            __out.AppendLine(false); //386:47
            __out.Append("                this._state = lexer.State;"); //387:1
            __out.AppendLine(false); //387:43
            __out.Append("            }"); //388:1
            __out.AppendLine(false); //388:14
            __out.Append("            internal int _state;"); //389:1
            __out.AppendLine(false); //389:33
            __out.Append("            internal int _mode;"); //390:1
            __out.AppendLine(false); //390:32
            __out.Append("            internal List<int> _modeStack;"); //391:1
            __out.AppendLine(false); //391:43
            __out.Append("            internal int _type;"); //392:1
            __out.AppendLine(false); //392:32
            __out.Append("            internal int _channel;"); //393:1
            __out.AppendLine(false); //393:35
            bool __tmp256_outputWritten = false;
            string __tmp257_line = "            public void Restore("; //394:1
            if (!string.IsNullOrEmpty(__tmp257_line))
            {
                __out.Append(__tmp257_line);
                __tmp256_outputWritten = true;
            }
            StringBuilder __tmp258 = new StringBuilder();
            __tmp258.Append(Properties.LanguageNamespace);
            using(StreamReader __tmp258Reader = new StreamReader(this.__ToStream(__tmp258.ToString())))
            {
                bool __tmp258_last = __tmp258Reader.EndOfStream;
                while(!__tmp258_last)
                {
                    string __tmp258_line = __tmp258Reader.ReadLine();
                    __tmp258_last = __tmp258Reader.EndOfStream;
                    if ((__tmp258_last && !string.IsNullOrEmpty(__tmp258_line)) || (!__tmp258_last && __tmp258_line != null))
                    {
                        __out.Append(__tmp258_line);
                        __tmp256_outputWritten = true;
                    }
                    if (!__tmp258_last) __out.AppendLine(true);
                }
            }
            string __tmp259_line = ".Syntax.InternalSyntax."; //394:63
            if (!string.IsNullOrEmpty(__tmp259_line))
            {
                __out.Append(__tmp259_line);
                __tmp256_outputWritten = true;
            }
            StringBuilder __tmp260 = new StringBuilder();
            __tmp260.Append(Properties.LanguageClassName);
            using(StreamReader __tmp260Reader = new StreamReader(this.__ToStream(__tmp260.ToString())))
            {
                bool __tmp260_last = __tmp260Reader.EndOfStream;
                while(!__tmp260_last)
                {
                    string __tmp260_line = __tmp260Reader.ReadLine();
                    __tmp260_last = __tmp260Reader.EndOfStream;
                    if ((__tmp260_last && !string.IsNullOrEmpty(__tmp260_line)) || (!__tmp260_last && __tmp260_line != null))
                    {
                        __out.Append(__tmp260_line);
                        __tmp256_outputWritten = true;
                    }
                    if (!__tmp260_last) __out.AppendLine(true);
                }
            }
            string __tmp261_line = "Lexer lexer)"; //394:116
            if (!string.IsNullOrEmpty(__tmp261_line))
            {
                __out.Append(__tmp261_line);
                __tmp256_outputWritten = true;
            }
            if (__tmp256_outputWritten) __out.AppendLine(true);
            if (__tmp256_outputWritten)
            {
                __out.AppendLine(false); //394:128
            }
            __out.Append("            {"); //395:1
            __out.AppendLine(false); //395:14
            __out.Append("                lexer.CurrentMode = this._mode;"); //396:1
            __out.AppendLine(false); //396:48
            __out.Append("                lexer.ModeStack.Clear();"); //397:1
            __out.AppendLine(false); //397:41
            __out.Append("                if (this._modeStack != null)"); //398:1
            __out.AppendLine(false); //398:45
            __out.Append("                {"); //399:1
            __out.AppendLine(false); //399:18
            __out.Append("                    foreach (var item in this._modeStack)"); //400:1
            __out.AppendLine(false); //400:58
            __out.Append("                    {"); //401:1
            __out.AppendLine(false); //401:22
            __out.Append("                        lexer.ModeStack.Push(item);"); //402:1
            __out.AppendLine(false); //402:52
            __out.Append("                    }"); //403:1
            __out.AppendLine(false); //403:22
            __out.Append("                }"); //404:1
            __out.AppendLine(false); //404:18
            __out.Append("                lexer.Type = this._type;"); //405:1
            __out.AppendLine(false); //405:41
            __out.Append("                lexer.Channel = this._channel;"); //406:1
            __out.AppendLine(false); //406:47
            __out.Append("                lexer.State = this._state;"); //407:1
            __out.AppendLine(false); //407:43
            __out.Append("            }"); //408:1
            __out.AppendLine(false); //408:14
            __out.Append("            public override bool Equals(object obj)"); //409:1
            __out.AppendLine(false); //409:52
            __out.Append("            {"); //410:1
            __out.AppendLine(false); //410:14
            __out.Append("                LanguageScannerState rhs = (LanguageScannerState)obj;"); //411:1
            __out.AppendLine(false); //411:70
            __out.Append("                if (rhs._mode != this._mode) return false;"); //412:1
            __out.AppendLine(false); //412:59
            __out.Append("                if (rhs._type != this._type) return false;"); //413:1
            __out.AppendLine(false); //413:59
            __out.Append("                if (rhs._state != this._state) return false;"); //414:1
            __out.AppendLine(false); //414:61
            __out.Append("                if (rhs._channel != this._channel) return false;"); //415:1
            __out.AppendLine(false); //415:65
            __out.Append("                if (rhs._modeStack == null && this._modeStack != null) return false;"); //416:1
            __out.AppendLine(false); //416:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack == null) return false;"); //417:1
            __out.AppendLine(false); //417:85
            __out.Append("                if (rhs._modeStack != null && this._modeStack != null)"); //418:1
            __out.AppendLine(false); //418:71
            __out.Append("                {"); //419:1
            __out.AppendLine(false); //419:18
            __out.Append("                    if (rhs._modeStack.Count != this._modeStack.Count) return false;"); //420:1
            __out.AppendLine(false); //420:85
            __out.Append("                    for (int i = 0; i < rhs._modeStack.Count; ++i)"); //421:1
            __out.AppendLine(false); //421:67
            __out.Append("                    {"); //422:1
            __out.AppendLine(false); //422:22
            bool __tmp263_outputWritten = false;
            string __tmp264_line = "                        if (rhs._modeStack"; //423:1
            if (!string.IsNullOrEmpty(__tmp264_line))
            {
                __out.Append(__tmp264_line);
                __tmp263_outputWritten = true;
            }
            StringBuilder __tmp265 = new StringBuilder();
            __tmp265.Append("[i]");
            using(StreamReader __tmp265Reader = new StreamReader(this.__ToStream(__tmp265.ToString())))
            {
                bool __tmp265_last = __tmp265Reader.EndOfStream;
                while(!__tmp265_last)
                {
                    string __tmp265_line = __tmp265Reader.ReadLine();
                    __tmp265_last = __tmp265Reader.EndOfStream;
                    if ((__tmp265_last && !string.IsNullOrEmpty(__tmp265_line)) || (!__tmp265_last && __tmp265_line != null))
                    {
                        __out.Append(__tmp265_line);
                        __tmp263_outputWritten = true;
                    }
                    if (!__tmp265_last) __out.AppendLine(true);
                }
            }
            string __tmp266_line = " != this._modeStack"; //423:50
            if (!string.IsNullOrEmpty(__tmp266_line))
            {
                __out.Append(__tmp266_line);
                __tmp263_outputWritten = true;
            }
            StringBuilder __tmp267 = new StringBuilder();
            __tmp267.Append("[i]");
            using(StreamReader __tmp267Reader = new StreamReader(this.__ToStream(__tmp267.ToString())))
            {
                bool __tmp267_last = __tmp267Reader.EndOfStream;
                while(!__tmp267_last)
                {
                    string __tmp267_line = __tmp267Reader.ReadLine();
                    __tmp267_last = __tmp267Reader.EndOfStream;
                    if ((__tmp267_last && !string.IsNullOrEmpty(__tmp267_line)) || (!__tmp267_last && __tmp267_line != null))
                    {
                        __out.Append(__tmp267_line);
                        __tmp263_outputWritten = true;
                    }
                    if (!__tmp267_last) __out.AppendLine(true);
                }
            }
            string __tmp268_line = ") return false;"; //423:76
            if (!string.IsNullOrEmpty(__tmp268_line))
            {
                __out.Append(__tmp268_line);
                __tmp263_outputWritten = true;
            }
            if (__tmp263_outputWritten) __out.AppendLine(true);
            if (__tmp263_outputWritten)
            {
                __out.AppendLine(false); //423:91
            }
            __out.Append("                    }"); //424:1
            __out.AppendLine(false); //424:22
            __out.Append("                }"); //425:1
            __out.AppendLine(false); //425:18
            __out.Append("                return true;"); //426:1
            __out.AppendLine(false); //426:29
            __out.Append("            }"); //427:1
            __out.AppendLine(false); //427:14
            __out.Append("            public override int GetHashCode()"); //428:1
            __out.AppendLine(false); //428:46
            __out.Append("            {"); //429:1
            __out.AppendLine(false); //429:14
            __out.Append("                int result = 0;"); //430:1
            __out.AppendLine(false); //430:32
            __out.Append("                result "); //431:1
            __out.Append("^"); //431:24
            __out.Append("= this._mode.GetHashCode();"); //431:25
            __out.AppendLine(false); //431:52
            __out.Append("                result "); //432:1
            __out.Append("^"); //432:24
            __out.Append("= this._type.GetHashCode();"); //432:25
            __out.AppendLine(false); //432:52
            __out.Append("                result "); //433:1
            __out.Append("^"); //433:24
            __out.Append("= this._state.GetHashCode();"); //433:25
            __out.AppendLine(false); //433:53
            __out.Append("                result "); //434:1
            __out.Append("^"); //434:24
            __out.Append("= this._channel.GetHashCode();"); //434:25
            __out.AppendLine(false); //434:55
            __out.Append("                if (this._modeStack != null)"); //435:1
            __out.AppendLine(false); //435:45
            __out.Append("                {"); //436:1
            __out.AppendLine(false); //436:18
            __out.Append("                    result "); //437:1
            __out.Append("^"); //437:28
            __out.Append("= this._modeStack.GetHashCode();"); //437:29
            __out.AppendLine(false); //437:61
            __out.Append("                }"); //438:1
            __out.AppendLine(false); //438:18
            __out.Append("                return result;"); //439:1
            __out.AppendLine(false); //439:31
            __out.Append("            }"); //440:1
            __out.AppendLine(false); //440:14
            __out.Append("        }"); //441:1
            __out.AppendLine(false); //441:10
            __out.Append("    }"); //442:1
            __out.AppendLine(false); //442:6
            bool __tmp270_outputWritten = false;
            string __tmp269Prefix = "    "; //443:1
            StringBuilder __tmp271 = new StringBuilder();
            __tmp271.Append("[ComVisible(true)]");
            using(StreamReader __tmp271Reader = new StreamReader(this.__ToStream(__tmp271.ToString())))
            {
                bool __tmp271_last = __tmp271Reader.EndOfStream;
                while(!__tmp271_last)
                {
                    string __tmp271_line = __tmp271Reader.ReadLine();
                    __tmp271_last = __tmp271Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp269Prefix))
                    {
                        __out.Append(__tmp269Prefix);
                        __tmp270_outputWritten = true;
                    }
                    if ((__tmp271_last && !string.IsNullOrEmpty(__tmp271_line)) || (!__tmp271_last && __tmp271_line != null))
                    {
                        __out.Append(__tmp271_line);
                        __tmp270_outputWritten = true;
                    }
                    if (!__tmp271_last || __tmp270_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp270_outputWritten)
            {
                __out.AppendLine(false); //443:27
            }
            bool __tmp273_outputWritten = false;
            string __tmp272Prefix = "    "; //444:1
            StringBuilder __tmp274 = new StringBuilder();
            __tmp274.Append("[Guid(" + Properties.LanguageClassName + "LanguageConfig." + Properties.LanguageClassName + "LanguageServiceGuid)]");
            using(StreamReader __tmp274Reader = new StreamReader(this.__ToStream(__tmp274.ToString())))
            {
                bool __tmp274_last = __tmp274Reader.EndOfStream;
                while(!__tmp274_last)
                {
                    string __tmp274_line = __tmp274Reader.ReadLine();
                    __tmp274_last = __tmp274Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp272Prefix))
                    {
                        __out.Append(__tmp272Prefix);
                        __tmp273_outputWritten = true;
                    }
                    if ((__tmp274_last && !string.IsNullOrEmpty(__tmp274_line)) || (!__tmp274_last && __tmp274_line != null))
                    {
                        __out.Append(__tmp274_line);
                        __tmp273_outputWritten = true;
                    }
                    if (!__tmp274_last || __tmp273_outputWritten) __out.AppendLine(true);
                }
            }
            if (__tmp273_outputWritten)
            {
                __out.AppendLine(false); //444:115
            }
            bool __tmp276_outputWritten = false;
            string __tmp277_line = "    public class "; //445:1
            if (!string.IsNullOrEmpty(__tmp277_line))
            {
                __out.Append(__tmp277_line);
                __tmp276_outputWritten = true;
            }
            StringBuilder __tmp278 = new StringBuilder();
            __tmp278.Append(Properties.LanguageClassName);
            using(StreamReader __tmp278Reader = new StreamReader(this.__ToStream(__tmp278.ToString())))
            {
                bool __tmp278_last = __tmp278Reader.EndOfStream;
                while(!__tmp278_last)
                {
                    string __tmp278_line = __tmp278Reader.ReadLine();
                    __tmp278_last = __tmp278Reader.EndOfStream;
                    if ((__tmp278_last && !string.IsNullOrEmpty(__tmp278_line)) || (!__tmp278_last && __tmp278_line != null))
                    {
                        __out.Append(__tmp278_line);
                        __tmp276_outputWritten = true;
                    }
                    if (!__tmp278_last) __out.AppendLine(true);
                }
            }
            string __tmp279_line = "LanguageService : LanguageService"; //445:48
            if (!string.IsNullOrEmpty(__tmp279_line))
            {
                __out.Append(__tmp279_line);
                __tmp276_outputWritten = true;
            }
            if (__tmp276_outputWritten) __out.AppendLine(true);
            if (__tmp276_outputWritten)
            {
                __out.AppendLine(false); //445:81
            }
            __out.Append("    {"); //446:1
            __out.AppendLine(false); //446:6
            __out.Append("        private LanguagePreferences preferences;"); //447:1
            __out.AppendLine(false); //447:49
            bool __tmp281_outputWritten = false;
            string __tmp282_line = "        private "; //448:1
            if (!string.IsNullOrEmpty(__tmp282_line))
            {
                __out.Append(__tmp282_line);
                __tmp281_outputWritten = true;
            }
            StringBuilder __tmp283 = new StringBuilder();
            __tmp283.Append(Properties.LanguageClassName);
            using(StreamReader __tmp283Reader = new StreamReader(this.__ToStream(__tmp283.ToString())))
            {
                bool __tmp283_last = __tmp283Reader.EndOfStream;
                while(!__tmp283_last)
                {
                    string __tmp283_line = __tmp283Reader.ReadLine();
                    __tmp283_last = __tmp283Reader.EndOfStream;
                    if ((__tmp283_last && !string.IsNullOrEmpty(__tmp283_line)) || (!__tmp283_last && __tmp283_line != null))
                    {
                        __out.Append(__tmp283_line);
                        __tmp281_outputWritten = true;
                    }
                    if (!__tmp283_last) __out.AppendLine(true);
                }
            }
            string __tmp284_line = "LanguageScanner scanner;"; //448:47
            if (!string.IsNullOrEmpty(__tmp284_line))
            {
                __out.Append(__tmp284_line);
                __tmp281_outputWritten = true;
            }
            if (__tmp281_outputWritten) __out.AppendLine(true);
            if (__tmp281_outputWritten)
            {
                __out.AppendLine(false); //448:71
            }
            bool __tmp286_outputWritten = false;
            string __tmp287_line = "        public "; //449:1
            if (!string.IsNullOrEmpty(__tmp287_line))
            {
                __out.Append(__tmp287_line);
                __tmp286_outputWritten = true;
            }
            StringBuilder __tmp288 = new StringBuilder();
            __tmp288.Append(Properties.LanguageClassName);
            using(StreamReader __tmp288Reader = new StreamReader(this.__ToStream(__tmp288.ToString())))
            {
                bool __tmp288_last = __tmp288Reader.EndOfStream;
                while(!__tmp288_last)
                {
                    string __tmp288_line = __tmp288Reader.ReadLine();
                    __tmp288_last = __tmp288Reader.EndOfStream;
                    if ((__tmp288_last && !string.IsNullOrEmpty(__tmp288_line)) || (!__tmp288_last && __tmp288_line != null))
                    {
                        __out.Append(__tmp288_line);
                        __tmp286_outputWritten = true;
                    }
                    if (!__tmp288_last) __out.AppendLine(true);
                }
            }
            string __tmp289_line = "LanguageService()"; //449:46
            if (!string.IsNullOrEmpty(__tmp289_line))
            {
                __out.Append(__tmp289_line);
                __tmp286_outputWritten = true;
            }
            if (__tmp286_outputWritten) __out.AppendLine(true);
            if (__tmp286_outputWritten)
            {
                __out.AppendLine(false); //449:63
            }
            __out.Append("        {"); //450:1
            __out.AppendLine(false); //450:10
            __out.Append("			// Creating the config instance"); //451:1
            __out.AppendLine(false); //451:35
            bool __tmp291_outputWritten = false;
            string __tmp290Prefix = "			"; //452:1
            StringBuilder __tmp292 = new StringBuilder();
            __tmp292.Append(Properties.LanguageClassName);
            using(StreamReader __tmp292Reader = new StreamReader(this.__ToStream(__tmp292.ToString())))
            {
                bool __tmp292_last = __tmp292Reader.EndOfStream;
                while(!__tmp292_last)
                {
                    string __tmp292_line = __tmp292Reader.ReadLine();
                    __tmp292_last = __tmp292Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp290Prefix))
                    {
                        __out.Append(__tmp290Prefix);
                        __tmp291_outputWritten = true;
                    }
                    if ((__tmp292_last && !string.IsNullOrEmpty(__tmp292_line)) || (!__tmp292_last && __tmp292_line != null))
                    {
                        __out.Append(__tmp292_line);
                        __tmp291_outputWritten = true;
                    }
                    if (!__tmp292_last) __out.AppendLine(true);
                }
            }
            string __tmp293_line = "LanguageConfigBase.Instance.ToString();"; //452:34
            if (!string.IsNullOrEmpty(__tmp293_line))
            {
                __out.Append(__tmp293_line);
                __tmp291_outputWritten = true;
            }
            if (__tmp291_outputWritten) __out.AppendLine(true);
            if (__tmp291_outputWritten)
            {
                __out.AppendLine(false); //452:73
            }
            __out.Append("        }"); //453:1
            __out.AppendLine(false); //453:10
            __out.Append("        public override string GetFormatFilterList()"); //454:1
            __out.AppendLine(false); //454:53
            __out.Append("        {"); //455:1
            __out.AppendLine(false); //455:10
            bool __tmp295_outputWritten = false;
            string __tmp296_line = "            return "; //456:1
            if (!string.IsNullOrEmpty(__tmp296_line))
            {
                __out.Append(__tmp296_line);
                __tmp295_outputWritten = true;
            }
            StringBuilder __tmp297 = new StringBuilder();
            __tmp297.Append(Properties.LanguageClassName);
            using(StreamReader __tmp297Reader = new StreamReader(this.__ToStream(__tmp297.ToString())))
            {
                bool __tmp297_last = __tmp297Reader.EndOfStream;
                while(!__tmp297_last)
                {
                    string __tmp297_line = __tmp297Reader.ReadLine();
                    __tmp297_last = __tmp297Reader.EndOfStream;
                    if ((__tmp297_last && !string.IsNullOrEmpty(__tmp297_line)) || (!__tmp297_last && __tmp297_line != null))
                    {
                        __out.Append(__tmp297_line);
                        __tmp295_outputWritten = true;
                    }
                    if (!__tmp297_last) __out.AppendLine(true);
                }
            }
            string __tmp298_line = "LanguageConfig.FilterList;"; //456:50
            if (!string.IsNullOrEmpty(__tmp298_line))
            {
                __out.Append(__tmp298_line);
                __tmp295_outputWritten = true;
            }
            if (__tmp295_outputWritten) __out.AppendLine(true);
            if (__tmp295_outputWritten)
            {
                __out.AppendLine(false); //456:76
            }
            __out.Append("        }"); //457:1
            __out.AppendLine(false); //457:10
            __out.Append("        public override LanguagePreferences GetLanguagePreferences()"); //458:1
            __out.AppendLine(false); //458:69
            __out.Append("        {"); //459:1
            __out.AppendLine(false); //459:10
            __out.Append("            if (preferences == null)"); //460:1
            __out.AppendLine(false); //460:37
            __out.Append("            {"); //461:1
            __out.AppendLine(false); //461:14
            bool __tmp300_outputWritten = false;
            string __tmp301_line = "                preferences = new LanguagePreferences(this.Site, typeof("; //462:1
            if (!string.IsNullOrEmpty(__tmp301_line))
            {
                __out.Append(__tmp301_line);
                __tmp300_outputWritten = true;
            }
            StringBuilder __tmp302 = new StringBuilder();
            __tmp302.Append(Properties.LanguageClassName);
            using(StreamReader __tmp302Reader = new StreamReader(this.__ToStream(__tmp302.ToString())))
            {
                bool __tmp302_last = __tmp302Reader.EndOfStream;
                while(!__tmp302_last)
                {
                    string __tmp302_line = __tmp302Reader.ReadLine();
                    __tmp302_last = __tmp302Reader.EndOfStream;
                    if ((__tmp302_last && !string.IsNullOrEmpty(__tmp302_line)) || (!__tmp302_last && __tmp302_line != null))
                    {
                        __out.Append(__tmp302_line);
                        __tmp300_outputWritten = true;
                    }
                    if (!__tmp302_last) __out.AppendLine(true);
                }
            }
            string __tmp303_line = "LanguageService).GUID, this.Name);"; //462:103
            if (!string.IsNullOrEmpty(__tmp303_line))
            {
                __out.Append(__tmp303_line);
                __tmp300_outputWritten = true;
            }
            if (__tmp300_outputWritten) __out.AppendLine(true);
            if (__tmp300_outputWritten)
            {
                __out.AppendLine(false); //462:137
            }
            __out.Append("                preferences.Init();"); //463:1
            __out.AppendLine(false); //463:36
            __out.Append("            }"); //464:1
            __out.AppendLine(false); //464:14
            __out.Append("            return preferences;"); //465:1
            __out.AppendLine(false); //465:32
            __out.Append("        }"); //466:1
            __out.AppendLine(false); //466:10
            __out.Append("        public override IScanner GetScanner(IVsTextLines buffer)"); //467:1
            __out.AppendLine(false); //467:65
            __out.Append("        {"); //468:1
            __out.AppendLine(false); //468:10
            __out.Append("            if (scanner == null)"); //469:1
            __out.AppendLine(false); //469:33
            __out.Append("            {"); //470:1
            __out.AppendLine(false); //470:14
            bool __tmp305_outputWritten = false;
            string __tmp306_line = "                scanner = new "; //471:1
            if (!string.IsNullOrEmpty(__tmp306_line))
            {
                __out.Append(__tmp306_line);
                __tmp305_outputWritten = true;
            }
            StringBuilder __tmp307 = new StringBuilder();
            __tmp307.Append(Properties.LanguageClassName);
            using(StreamReader __tmp307Reader = new StreamReader(this.__ToStream(__tmp307.ToString())))
            {
                bool __tmp307_last = __tmp307Reader.EndOfStream;
                while(!__tmp307_last)
                {
                    string __tmp307_line = __tmp307Reader.ReadLine();
                    __tmp307_last = __tmp307Reader.EndOfStream;
                    if ((__tmp307_last && !string.IsNullOrEmpty(__tmp307_line)) || (!__tmp307_last && __tmp307_line != null))
                    {
                        __out.Append(__tmp307_line);
                        __tmp305_outputWritten = true;
                    }
                    if (!__tmp307_last) __out.AppendLine(true);
                }
            }
            string __tmp308_line = "LanguageScanner();"; //471:61
            if (!string.IsNullOrEmpty(__tmp308_line))
            {
                __out.Append(__tmp308_line);
                __tmp305_outputWritten = true;
            }
            if (__tmp305_outputWritten) __out.AppendLine(true);
            if (__tmp305_outputWritten)
            {
                __out.AppendLine(false); //471:79
            }
            __out.Append("            }"); //472:1
            __out.AppendLine(false); //472:14
            __out.Append("            return scanner;"); //473:1
            __out.AppendLine(false); //473:28
            __out.Append("        }"); //474:1
            __out.AppendLine(false); //474:10
            __out.Append("        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)"); //475:1
            __out.AppendLine(false); //475:96
            __out.Append("        {"); //476:1
            __out.AppendLine(false); //476:10
            bool __tmp310_outputWritten = false;
            string __tmp311_line = "            return new "; //477:1
            if (!string.IsNullOrEmpty(__tmp311_line))
            {
                __out.Append(__tmp311_line);
                __tmp310_outputWritten = true;
            }
            StringBuilder __tmp312 = new StringBuilder();
            __tmp312.Append(Properties.LanguageClassName);
            using(StreamReader __tmp312Reader = new StreamReader(this.__ToStream(__tmp312.ToString())))
            {
                bool __tmp312_last = __tmp312Reader.EndOfStream;
                while(!__tmp312_last)
                {
                    string __tmp312_line = __tmp312Reader.ReadLine();
                    __tmp312_last = __tmp312Reader.EndOfStream;
                    if ((__tmp312_last && !string.IsNullOrEmpty(__tmp312_line)) || (!__tmp312_last && __tmp312_line != null))
                    {
                        __out.Append(__tmp312_line);
                        __tmp310_outputWritten = true;
                    }
                    if (!__tmp312_last) __out.AppendLine(true);
                }
            }
            string __tmp313_line = "LanguageSource(this, buffer, this.GetColorizer(buffer));"; //477:54
            if (!string.IsNullOrEmpty(__tmp313_line))
            {
                __out.Append(__tmp313_line);
                __tmp310_outputWritten = true;
            }
            if (__tmp310_outputWritten) __out.AppendLine(true);
            if (__tmp310_outputWritten)
            {
                __out.AppendLine(false); //477:110
            }
            __out.Append("        }"); //478:1
            __out.AppendLine(false); //478:10
            __out.Append("        #region Custom Colors"); //479:1
            __out.AppendLine(false); //479:30
            __out.Append("        public override int GetColorableItem(int index, out IVsColorableItem item)"); //480:1
            __out.AppendLine(false); //480:83
            __out.Append("        {"); //481:1
            __out.AppendLine(false); //481:10
            bool __tmp315_outputWritten = false;
            string __tmp316_line = "            if (index >= 0 && index < "; //482:1
            if (!string.IsNullOrEmpty(__tmp316_line))
            {
                __out.Append(__tmp316_line);
                __tmp315_outputWritten = true;
            }
            StringBuilder __tmp317 = new StringBuilder();
            __tmp317.Append(Properties.LanguageClassName);
            using(StreamReader __tmp317Reader = new StreamReader(this.__ToStream(__tmp317.ToString())))
            {
                bool __tmp317_last = __tmp317Reader.EndOfStream;
                while(!__tmp317_last)
                {
                    string __tmp317_line = __tmp317Reader.ReadLine();
                    __tmp317_last = __tmp317Reader.EndOfStream;
                    if ((__tmp317_last && !string.IsNullOrEmpty(__tmp317_line)) || (!__tmp317_last && __tmp317_line != null))
                    {
                        __out.Append(__tmp317_line);
                        __tmp315_outputWritten = true;
                    }
                    if (!__tmp317_last) __out.AppendLine(true);
                }
            }
            string __tmp318_line = "LanguageConfig.Instance.ColorableItems.Count)"; //482:69
            if (!string.IsNullOrEmpty(__tmp318_line))
            {
                __out.Append(__tmp318_line);
                __tmp315_outputWritten = true;
            }
            if (__tmp315_outputWritten) __out.AppendLine(true);
            if (__tmp315_outputWritten)
            {
                __out.AppendLine(false); //482:114
            }
            __out.Append("            {"); //483:1
            __out.AppendLine(false); //483:14
            bool __tmp320_outputWritten = false;
            string __tmp321_line = "                item = "; //484:1
            if (!string.IsNullOrEmpty(__tmp321_line))
            {
                __out.Append(__tmp321_line);
                __tmp320_outputWritten = true;
            }
            StringBuilder __tmp322 = new StringBuilder();
            __tmp322.Append(Properties.LanguageClassName);
            using(StreamReader __tmp322Reader = new StreamReader(this.__ToStream(__tmp322.ToString())))
            {
                bool __tmp322_last = __tmp322Reader.EndOfStream;
                while(!__tmp322_last)
                {
                    string __tmp322_line = __tmp322Reader.ReadLine();
                    __tmp322_last = __tmp322Reader.EndOfStream;
                    if ((__tmp322_last && !string.IsNullOrEmpty(__tmp322_line)) || (!__tmp322_last && __tmp322_line != null))
                    {
                        __out.Append(__tmp322_line);
                        __tmp320_outputWritten = true;
                    }
                    if (!__tmp322_last) __out.AppendLine(true);
                }
            }
            string __tmp323_line = "LanguageConfig.Instance.ColorableItems"; //484:54
            if (!string.IsNullOrEmpty(__tmp323_line))
            {
                __out.Append(__tmp323_line);
                __tmp320_outputWritten = true;
            }
            StringBuilder __tmp324 = new StringBuilder();
            __tmp324.Append("[index]");
            using(StreamReader __tmp324Reader = new StreamReader(this.__ToStream(__tmp324.ToString())))
            {
                bool __tmp324_last = __tmp324Reader.EndOfStream;
                while(!__tmp324_last)
                {
                    string __tmp324_line = __tmp324Reader.ReadLine();
                    __tmp324_last = __tmp324Reader.EndOfStream;
                    if ((__tmp324_last && !string.IsNullOrEmpty(__tmp324_line)) || (!__tmp324_last && __tmp324_line != null))
                    {
                        __out.Append(__tmp324_line);
                        __tmp320_outputWritten = true;
                    }
                    if (!__tmp324_last) __out.AppendLine(true);
                }
            }
            string __tmp325_line = ";"; //484:103
            if (!string.IsNullOrEmpty(__tmp325_line))
            {
                __out.Append(__tmp325_line);
                __tmp320_outputWritten = true;
            }
            if (__tmp320_outputWritten) __out.AppendLine(true);
            if (__tmp320_outputWritten)
            {
                __out.AppendLine(false); //484:104
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //485:1
            __out.AppendLine(false); //485:64
            __out.Append("            }"); //486:1
            __out.AppendLine(false); //486:14
            __out.Append("            else"); //487:1
            __out.AppendLine(false); //487:17
            __out.Append("            {"); //488:1
            __out.AppendLine(false); //488:14
            bool __tmp327_outputWritten = false;
            string __tmp328_line = "                item = "; //489:1
            if (!string.IsNullOrEmpty(__tmp328_line))
            {
                __out.Append(__tmp328_line);
                __tmp327_outputWritten = true;
            }
            StringBuilder __tmp329 = new StringBuilder();
            __tmp329.Append(Properties.LanguageClassName);
            using(StreamReader __tmp329Reader = new StreamReader(this.__ToStream(__tmp329.ToString())))
            {
                bool __tmp329_last = __tmp329Reader.EndOfStream;
                while(!__tmp329_last)
                {
                    string __tmp329_line = __tmp329Reader.ReadLine();
                    __tmp329_last = __tmp329Reader.EndOfStream;
                    if ((__tmp329_last && !string.IsNullOrEmpty(__tmp329_line)) || (!__tmp329_last && __tmp329_line != null))
                    {
                        __out.Append(__tmp329_line);
                        __tmp327_outputWritten = true;
                    }
                    if (!__tmp329_last) __out.AppendLine(true);
                }
            }
            string __tmp330_line = "LanguageConfig.Instance.ColorableItems"; //489:54
            if (!string.IsNullOrEmpty(__tmp330_line))
            {
                __out.Append(__tmp330_line);
                __tmp327_outputWritten = true;
            }
            StringBuilder __tmp331 = new StringBuilder();
            __tmp331.Append("[0]");
            using(StreamReader __tmp331Reader = new StreamReader(this.__ToStream(__tmp331.ToString())))
            {
                bool __tmp331_last = __tmp331Reader.EndOfStream;
                while(!__tmp331_last)
                {
                    string __tmp331_line = __tmp331Reader.ReadLine();
                    __tmp331_last = __tmp331Reader.EndOfStream;
                    if ((__tmp331_last && !string.IsNullOrEmpty(__tmp331_line)) || (!__tmp331_last && __tmp331_line != null))
                    {
                        __out.Append(__tmp331_line);
                        __tmp327_outputWritten = true;
                    }
                    if (!__tmp331_last) __out.AppendLine(true);
                }
            }
            string __tmp332_line = ";"; //489:99
            if (!string.IsNullOrEmpty(__tmp332_line))
            {
                __out.Append(__tmp332_line);
                __tmp327_outputWritten = true;
            }
            if (__tmp327_outputWritten) __out.AppendLine(true);
            if (__tmp327_outputWritten)
            {
                __out.AppendLine(false); //489:100
            }
            __out.Append("                return Microsoft.VisualStudio.VSConstants.S_OK;"); //490:1
            __out.AppendLine(false); //490:64
            __out.Append("            }"); //491:1
            __out.AppendLine(false); //491:14
            __out.Append("        }"); //492:1
            __out.AppendLine(false); //492:10
            __out.Append("        public override int GetItemCount(out int count)"); //493:1
            __out.AppendLine(false); //493:56
            __out.Append("        {"); //494:1
            __out.AppendLine(false); //494:10
            bool __tmp334_outputWritten = false;
            string __tmp335_line = "            count = "; //495:1
            if (!string.IsNullOrEmpty(__tmp335_line))
            {
                __out.Append(__tmp335_line);
                __tmp334_outputWritten = true;
            }
            StringBuilder __tmp336 = new StringBuilder();
            __tmp336.Append(Properties.LanguageClassName);
            using(StreamReader __tmp336Reader = new StreamReader(this.__ToStream(__tmp336.ToString())))
            {
                bool __tmp336_last = __tmp336Reader.EndOfStream;
                while(!__tmp336_last)
                {
                    string __tmp336_line = __tmp336Reader.ReadLine();
                    __tmp336_last = __tmp336Reader.EndOfStream;
                    if ((__tmp336_last && !string.IsNullOrEmpty(__tmp336_line)) || (!__tmp336_last && __tmp336_line != null))
                    {
                        __out.Append(__tmp336_line);
                        __tmp334_outputWritten = true;
                    }
                    if (!__tmp336_last) __out.AppendLine(true);
                }
            }
            string __tmp337_line = "LanguageConfig.Instance.ColorableItems.Count;"; //495:51
            if (!string.IsNullOrEmpty(__tmp337_line))
            {
                __out.Append(__tmp337_line);
                __tmp334_outputWritten = true;
            }
            if (__tmp334_outputWritten) __out.AppendLine(true);
            if (__tmp334_outputWritten)
            {
                __out.AppendLine(false); //495:96
            }
            __out.Append("            return Microsoft.VisualStudio.VSConstants.S_OK;"); //496:1
            __out.AppendLine(false); //496:60
            __out.Append("        }"); //497:1
            __out.AppendLine(false); //497:10
            __out.Append("        #endregion"); //498:1
            __out.AppendLine(false); //498:19
            __out.Append("        public override void OnIdle(bool periodic)"); //499:1
            __out.AppendLine(false); //499:51
            __out.Append("        {"); //500:1
            __out.AppendLine(false); //500:10
            __out.Append("            // from IronPythonLanguage sample"); //501:1
            __out.AppendLine(false); //501:46
            __out.Append("            // this appears to be necessary to get a parse request with ParseReason = Check?"); //502:1
            __out.AppendLine(false); //502:93
            bool __tmp339_outputWritten = false;
            string __tmp338Prefix = "            "; //503:1
            StringBuilder __tmp340 = new StringBuilder();
            __tmp340.Append(Properties.LanguageClassName);
            using(StreamReader __tmp340Reader = new StreamReader(this.__ToStream(__tmp340.ToString())))
            {
                bool __tmp340_last = __tmp340Reader.EndOfStream;
                while(!__tmp340_last)
                {
                    string __tmp340_line = __tmp340Reader.ReadLine();
                    __tmp340_last = __tmp340Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp338Prefix))
                    {
                        __out.Append(__tmp338Prefix);
                        __tmp339_outputWritten = true;
                    }
                    if ((__tmp340_last && !string.IsNullOrEmpty(__tmp340_line)) || (!__tmp340_last && __tmp340_line != null))
                    {
                        __out.Append(__tmp340_line);
                        __tmp339_outputWritten = true;
                    }
                    if (!__tmp340_last) __out.AppendLine(true);
                }
            }
            string __tmp341_line = "LanguageSource src = ("; //503:43
            if (!string.IsNullOrEmpty(__tmp341_line))
            {
                __out.Append(__tmp341_line);
                __tmp339_outputWritten = true;
            }
            StringBuilder __tmp342 = new StringBuilder();
            __tmp342.Append(Properties.LanguageClassName);
            using(StreamReader __tmp342Reader = new StreamReader(this.__ToStream(__tmp342.ToString())))
            {
                bool __tmp342_last = __tmp342Reader.EndOfStream;
                while(!__tmp342_last)
                {
                    string __tmp342_line = __tmp342Reader.ReadLine();
                    __tmp342_last = __tmp342Reader.EndOfStream;
                    if ((__tmp342_last && !string.IsNullOrEmpty(__tmp342_line)) || (!__tmp342_last && __tmp342_line != null))
                    {
                        __out.Append(__tmp342_line);
                        __tmp339_outputWritten = true;
                    }
                    if (!__tmp342_last) __out.AppendLine(true);
                }
            }
            string __tmp343_line = "LanguageSource)GetSource(this.LastActiveTextView);"; //503:95
            if (!string.IsNullOrEmpty(__tmp343_line))
            {
                __out.Append(__tmp343_line);
                __tmp339_outputWritten = true;
            }
            if (__tmp339_outputWritten) __out.AppendLine(true);
            if (__tmp339_outputWritten)
            {
                __out.AppendLine(false); //503:145
            }
            __out.Append("            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)"); //504:1
            __out.AppendLine(false); //504:74
            __out.Append("            {"); //505:1
            __out.AppendLine(false); //505:14
            __out.Append("                src.LastParseTime = 0;"); //506:1
            __out.AppendLine(false); //506:39
            __out.Append("            }"); //507:1
            __out.AppendLine(false); //507:14
            __out.Append("            base.OnIdle(periodic);"); //508:1
            __out.AppendLine(false); //508:35
            __out.Append("        }"); //509:1
            __out.AppendLine(false); //509:10
            __out.Append("        public override string Name"); //510:1
            __out.AppendLine(false); //510:36
            __out.Append("        {"); //511:1
            __out.AppendLine(false); //511:10
            bool __tmp345_outputWritten = false;
            string __tmp346_line = "            get { return "; //512:1
            if (!string.IsNullOrEmpty(__tmp346_line))
            {
                __out.Append(__tmp346_line);
                __tmp345_outputWritten = true;
            }
            StringBuilder __tmp347 = new StringBuilder();
            __tmp347.Append(Properties.LanguageClassName);
            using(StreamReader __tmp347Reader = new StreamReader(this.__ToStream(__tmp347.ToString())))
            {
                bool __tmp347_last = __tmp347Reader.EndOfStream;
                while(!__tmp347_last)
                {
                    string __tmp347_line = __tmp347Reader.ReadLine();
                    __tmp347_last = __tmp347Reader.EndOfStream;
                    if ((__tmp347_last && !string.IsNullOrEmpty(__tmp347_line)) || (!__tmp347_last && __tmp347_line != null))
                    {
                        __out.Append(__tmp347_line);
                        __tmp345_outputWritten = true;
                    }
                    if (!__tmp347_last) __out.AppendLine(true);
                }
            }
            string __tmp348_line = "LanguageConfig.LanguageName; }"; //512:56
            if (!string.IsNullOrEmpty(__tmp348_line))
            {
                __out.Append(__tmp348_line);
                __tmp345_outputWritten = true;
            }
            if (__tmp345_outputWritten) __out.AppendLine(true);
            if (__tmp345_outputWritten)
            {
                __out.AppendLine(false); //512:86
            }
            __out.Append("        }"); //513:1
            __out.AppendLine(false); //513:10
            __out.Append("        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)"); //514:1
            __out.AppendLine(false); //514:96
            __out.Append("        {"); //515:1
            __out.AppendLine(false); //515:10
            bool __tmp350_outputWritten = false;
            string __tmp351_line = "            return new "; //516:1
            if (!string.IsNullOrEmpty(__tmp351_line))
            {
                __out.Append(__tmp351_line);
                __tmp350_outputWritten = true;
            }
            StringBuilder __tmp352 = new StringBuilder();
            __tmp352.Append(Properties.LanguageClassName);
            using(StreamReader __tmp352Reader = new StreamReader(this.__ToStream(__tmp352.ToString())))
            {
                bool __tmp352_last = __tmp352Reader.EndOfStream;
                while(!__tmp352_last)
                {
                    string __tmp352_line = __tmp352Reader.ReadLine();
                    __tmp352_last = __tmp352Reader.EndOfStream;
                    if ((__tmp352_last && !string.IsNullOrEmpty(__tmp352_line)) || (!__tmp352_last && __tmp352_line != null))
                    {
                        __out.Append(__tmp352_line);
                        __tmp350_outputWritten = true;
                    }
                    if (!__tmp352_last) __out.AppendLine(true);
                }
            }
            string __tmp353_line = "LanguageViewFilter(mgr, newView);"; //516:54
            if (!string.IsNullOrEmpty(__tmp353_line))
            {
                __out.Append(__tmp353_line);
                __tmp350_outputWritten = true;
            }
            if (__tmp350_outputWritten) __out.AppendLine(true);
            if (__tmp350_outputWritten)
            {
                __out.AppendLine(false); //516:87
            }
            __out.Append("        }"); //517:1
            __out.AppendLine(false); //517:10
            __out.Append("        public override Colorizer GetColorizer(IVsTextLines buffer)"); //518:1
            __out.AppendLine(false); //518:68
            __out.Append("        {"); //519:1
            __out.AppendLine(false); //519:10
            bool __tmp355_outputWritten = false;
            string __tmp356_line = "            return new "; //520:1
            if (!string.IsNullOrEmpty(__tmp356_line))
            {
                __out.Append(__tmp356_line);
                __tmp355_outputWritten = true;
            }
            StringBuilder __tmp357 = new StringBuilder();
            __tmp357.Append(Properties.LanguageClassName);
            using(StreamReader __tmp357Reader = new StreamReader(this.__ToStream(__tmp357.ToString())))
            {
                bool __tmp357_last = __tmp357Reader.EndOfStream;
                while(!__tmp357_last)
                {
                    string __tmp357_line = __tmp357Reader.ReadLine();
                    __tmp357_last = __tmp357Reader.EndOfStream;
                    if ((__tmp357_last && !string.IsNullOrEmpty(__tmp357_line)) || (!__tmp357_last && __tmp357_line != null))
                    {
                        __out.Append(__tmp357_line);
                        __tmp355_outputWritten = true;
                    }
                    if (!__tmp357_last) __out.AppendLine(true);
                }
            }
            string __tmp358_line = "LanguageColorizer(this, buffer, this.GetScanner(buffer));"; //520:54
            if (!string.IsNullOrEmpty(__tmp358_line))
            {
                __out.Append(__tmp358_line);
                __tmp355_outputWritten = true;
            }
            if (__tmp355_outputWritten) __out.AppendLine(true);
            if (__tmp355_outputWritten)
            {
                __out.AppendLine(false); //520:111
            }
            __out.Append("        }"); //521:1
            __out.AppendLine(false); //521:10
            __out.Append("        public override AuthoringScope ParseSource(ParseRequest req)"); //522:1
            __out.AppendLine(false); //522:69
            __out.Append("        {"); //523:1
            __out.AppendLine(false); //523:10
            __out.Append("			try"); //524:1
            __out.AppendLine(false); //524:7
            __out.Append("			{"); //525:1
            __out.AppendLine(false); //525:5
            bool __tmp360_outputWritten = false;
            string __tmp359Prefix = "				"; //526:1
            StringBuilder __tmp361 = new StringBuilder();
            __tmp361.Append(Properties.LanguageClassName);
            using(StreamReader __tmp361Reader = new StreamReader(this.__ToStream(__tmp361.ToString())))
            {
                bool __tmp361_last = __tmp361Reader.EndOfStream;
                while(!__tmp361_last)
                {
                    string __tmp361_line = __tmp361Reader.ReadLine();
                    __tmp361_last = __tmp361Reader.EndOfStream;
                    if (!string.IsNullOrEmpty(__tmp359Prefix))
                    {
                        __out.Append(__tmp359Prefix);
                        __tmp360_outputWritten = true;
                    }
                    if ((__tmp361_last && !string.IsNullOrEmpty(__tmp361_line)) || (!__tmp361_last && __tmp361_line != null))
                    {
                        __out.Append(__tmp361_line);
                        __tmp360_outputWritten = true;
                    }
                    if (!__tmp361_last) __out.AppendLine(true);
                }
            }
            string __tmp362_line = "LanguageSource source = ("; //526:35
            if (!string.IsNullOrEmpty(__tmp362_line))
            {
                __out.Append(__tmp362_line);
                __tmp360_outputWritten = true;
            }
            StringBuilder __tmp363 = new StringBuilder();
            __tmp363.Append(Properties.LanguageClassName);
            using(StreamReader __tmp363Reader = new StreamReader(this.__ToStream(__tmp363.ToString())))
            {
                bool __tmp363_last = __tmp363Reader.EndOfStream;
                while(!__tmp363_last)
                {
                    string __tmp363_line = __tmp363Reader.ReadLine();
                    __tmp363_last = __tmp363Reader.EndOfStream;
                    if ((__tmp363_last && !string.IsNullOrEmpty(__tmp363_line)) || (!__tmp363_last && __tmp363_line != null))
                    {
                        __out.Append(__tmp363_line);
                        __tmp360_outputWritten = true;
                    }
                    if (!__tmp363_last) __out.AppendLine(true);
                }
            }
            string __tmp364_line = "LanguageSource)this.GetSource(req.FileName);"; //526:90
            if (!string.IsNullOrEmpty(__tmp364_line))
            {
                __out.Append(__tmp364_line);
                __tmp360_outputWritten = true;
            }
            if (__tmp360_outputWritten) __out.AppendLine(true);
            if (__tmp360_outputWritten)
            {
                __out.AppendLine(false); //526:134
            }
            __out.Append("				switch (req.Reason)"); //527:1
            __out.AppendLine(false); //527:24
            __out.Append("				{"); //528:1
            __out.AppendLine(false); //528:6
            __out.Append("					case ParseReason.Check:"); //529:1
            __out.AppendLine(false); //529:29
            __out.Append("						// This is where you perform your syntax highlighting."); //530:1
            __out.AppendLine(false); //530:61
            __out.Append("						// Parse entire source as given in req.Text."); //531:1
            __out.AppendLine(false); //531:51
            __out.Append("						// Store results in the AuthoringScope object."); //532:1
            __out.AppendLine(false); //532:53
            __out.Append("						string fileName = Path.GetFileName(req.FileName);"); //533:1
            __out.AppendLine(false); //533:56
            __out.Append("						string inputDir = Path.GetDirectoryName(req.FileName);"); //534:1
            __out.AppendLine(false); //534:61
            if (Properties.RoslynCompiler) //535:8
            {
                bool __tmp366_outputWritten = false;
                string __tmp367_line = "                        var metaModelReference = MetaDslx.Compiler.MetadataReference.CreateFromModel("; //536:1
                if (!string.IsNullOrEmpty(__tmp367_line))
                {
                    __out.Append(__tmp367_line);
                    __tmp366_outputWritten = true;
                }
                StringBuilder __tmp368 = new StringBuilder();
                __tmp368.Append(Properties.LanguageNamespace);
                using(StreamReader __tmp368Reader = new StreamReader(this.__ToStream(__tmp368.ToString())))
                {
                    bool __tmp368_last = __tmp368Reader.EndOfStream;
                    while(!__tmp368_last)
                    {
                        string __tmp368_line = __tmp368Reader.ReadLine();
                        __tmp368_last = __tmp368Reader.EndOfStream;
                        if ((__tmp368_last && !string.IsNullOrEmpty(__tmp368_line)) || (!__tmp368_last && __tmp368_line != null))
                        {
                            __out.Append(__tmp368_line);
                            __tmp366_outputWritten = true;
                        }
                        if (!__tmp368_last) __out.AppendLine(true);
                    }
                }
                string __tmp369_line = ".Symbols."; //536:132
                if (!string.IsNullOrEmpty(__tmp369_line))
                {
                    __out.Append(__tmp369_line);
                    __tmp366_outputWritten = true;
                }
                StringBuilder __tmp370 = new StringBuilder();
                __tmp370.Append(Properties.LanguageName);
                using(StreamReader __tmp370Reader = new StreamReader(this.__ToStream(__tmp370.ToString())))
                {
                    bool __tmp370_last = __tmp370Reader.EndOfStream;
                    while(!__tmp370_last)
                    {
                        string __tmp370_line = __tmp370Reader.ReadLine();
                        __tmp370_last = __tmp370Reader.EndOfStream;
                        if ((__tmp370_last && !string.IsNullOrEmpty(__tmp370_line)) || (!__tmp370_last && __tmp370_line != null))
                        {
                            __out.Append(__tmp370_line);
                            __tmp366_outputWritten = true;
                        }
                        if (!__tmp370_last) __out.AppendLine(true);
                    }
                }
                string __tmp371_line = "Instance.Model);"; //536:166
                if (!string.IsNullOrEmpty(__tmp371_line))
                {
                    __out.Append(__tmp371_line);
                    __tmp366_outputWritten = true;
                }
                if (__tmp366_outputWritten) __out.AppendLine(true);
                if (__tmp366_outputWritten)
                {
                    __out.AppendLine(false); //536:182
                }
                bool __tmp373_outputWritten = false;
                string __tmp374_line = "                        var tree = "; //537:1
                if (!string.IsNullOrEmpty(__tmp374_line))
                {
                    __out.Append(__tmp374_line);
                    __tmp373_outputWritten = true;
                }
                StringBuilder __tmp375 = new StringBuilder();
                __tmp375.Append(Properties.LanguageNamespace);
                using(StreamReader __tmp375Reader = new StreamReader(this.__ToStream(__tmp375.ToString())))
                {
                    bool __tmp375_last = __tmp375Reader.EndOfStream;
                    while(!__tmp375_last)
                    {
                        string __tmp375_line = __tmp375Reader.ReadLine();
                        __tmp375_last = __tmp375Reader.EndOfStream;
                        if ((__tmp375_last && !string.IsNullOrEmpty(__tmp375_line)) || (!__tmp375_last && __tmp375_line != null))
                        {
                            __out.Append(__tmp375_line);
                            __tmp373_outputWritten = true;
                        }
                        if (!__tmp375_last) __out.AppendLine(true);
                    }
                }
                string __tmp376_line = ".Syntax."; //537:66
                if (!string.IsNullOrEmpty(__tmp376_line))
                {
                    __out.Append(__tmp376_line);
                    __tmp373_outputWritten = true;
                }
                StringBuilder __tmp377 = new StringBuilder();
                __tmp377.Append(Properties.LanguageClassName);
                using(StreamReader __tmp377Reader = new StreamReader(this.__ToStream(__tmp377.ToString())))
                {
                    bool __tmp377_last = __tmp377Reader.EndOfStream;
                    while(!__tmp377_last)
                    {
                        string __tmp377_line = __tmp377Reader.ReadLine();
                        __tmp377_last = __tmp377Reader.EndOfStream;
                        if ((__tmp377_last && !string.IsNullOrEmpty(__tmp377_line)) || (!__tmp377_last && __tmp377_line != null))
                        {
                            __out.Append(__tmp377_line);
                            __tmp373_outputWritten = true;
                        }
                        if (!__tmp377_last) __out.AppendLine(true);
                    }
                }
                string __tmp378_line = "SyntaxTree.ParseText(req.Text);"; //537:104
                if (!string.IsNullOrEmpty(__tmp378_line))
                {
                    __out.Append(__tmp378_line);
                    __tmp373_outputWritten = true;
                }
                if (__tmp373_outputWritten) __out.AppendLine(true);
                if (__tmp373_outputWritten)
                {
                    __out.AppendLine(false); //537:135
                }
                bool __tmp380_outputWritten = false;
                string __tmp381_line = "                        var compilation = "; //538:1
                if (!string.IsNullOrEmpty(__tmp381_line))
                {
                    __out.Append(__tmp381_line);
                    __tmp380_outputWritten = true;
                }
                StringBuilder __tmp382 = new StringBuilder();
                __tmp382.Append(Properties.LanguageNamespace);
                using(StreamReader __tmp382Reader = new StreamReader(this.__ToStream(__tmp382.ToString())))
                {
                    bool __tmp382_last = __tmp382Reader.EndOfStream;
                    while(!__tmp382_last)
                    {
                        string __tmp382_line = __tmp382Reader.ReadLine();
                        __tmp382_last = __tmp382Reader.EndOfStream;
                        if ((__tmp382_last && !string.IsNullOrEmpty(__tmp382_line)) || (!__tmp382_last && __tmp382_line != null))
                        {
                            __out.Append(__tmp382_line);
                            __tmp380_outputWritten = true;
                        }
                        if (!__tmp382_last) __out.AppendLine(true);
                    }
                }
                string __tmp383_line = "."; //538:73
                if (!string.IsNullOrEmpty(__tmp383_line))
                {
                    __out.Append(__tmp383_line);
                    __tmp380_outputWritten = true;
                }
                StringBuilder __tmp384 = new StringBuilder();
                __tmp384.Append(Properties.LanguageClassName);
                using(StreamReader __tmp384Reader = new StreamReader(this.__ToStream(__tmp384.ToString())))
                {
                    bool __tmp384_last = __tmp384Reader.EndOfStream;
                    while(!__tmp384_last)
                    {
                        string __tmp384_line = __tmp384Reader.ReadLine();
                        __tmp384_last = __tmp384Reader.EndOfStream;
                        if ((__tmp384_last && !string.IsNullOrEmpty(__tmp384_line)) || (!__tmp384_last && __tmp384_line != null))
                        {
                            __out.Append(__tmp384_line);
                            __tmp380_outputWritten = true;
                        }
                        if (!__tmp384_last) __out.AppendLine(true);
                    }
                }
                string __tmp385_line = "Compilation.Create(\""; //538:104
                if (!string.IsNullOrEmpty(__tmp385_line))
                {
                    __out.Append(__tmp385_line);
                    __tmp380_outputWritten = true;
                }
                StringBuilder __tmp386 = new StringBuilder();
                __tmp386.Append(Properties.LanguageClassName);
                using(StreamReader __tmp386Reader = new StreamReader(this.__ToStream(__tmp386.ToString())))
                {
                    bool __tmp386_last = __tmp386Reader.EndOfStream;
                    while(!__tmp386_last)
                    {
                        string __tmp386_line = __tmp386Reader.ReadLine();
                        __tmp386_last = __tmp386Reader.EndOfStream;
                        if ((__tmp386_last && !string.IsNullOrEmpty(__tmp386_line)) || (!__tmp386_last && __tmp386_line != null))
                        {
                            __out.Append(__tmp386_line);
                            __tmp380_outputWritten = true;
                        }
                        if (!__tmp386_last) __out.AppendLine(true);
                    }
                }
                string __tmp387_line = "\").AddReferences(metaModelReference).AddSyntaxTrees(tree);"; //538:154
                if (!string.IsNullOrEmpty(__tmp387_line))
                {
                    __out.Append(__tmp387_line);
                    __tmp380_outputWritten = true;
                }
                if (__tmp380_outputWritten) __out.AppendLine(true);
                if (__tmp380_outputWritten)
                {
                    __out.AppendLine(false); //538:212
                }
                __out.Append("                        var immutableModel = compilation.Model;"); //539:1
                __out.AppendLine(false); //539:64
            }
            else //540:8
            {
                bool __tmp389_outputWritten = false;
                string __tmp390_line = "						var compilation = new "; //541:1
                if (!string.IsNullOrEmpty(__tmp390_line))
                {
                    __out.Append(__tmp390_line);
                    __tmp389_outputWritten = true;
                }
                StringBuilder __tmp391 = new StringBuilder();
                __tmp391.Append(Properties.LanguageNamespace);
                using(StreamReader __tmp391Reader = new StreamReader(this.__ToStream(__tmp391.ToString())))
                {
                    bool __tmp391_last = __tmp391Reader.EndOfStream;
                    while(!__tmp391_last)
                    {
                        string __tmp391_line = __tmp391Reader.ReadLine();
                        __tmp391_last = __tmp391Reader.EndOfStream;
                        if ((__tmp391_last && !string.IsNullOrEmpty(__tmp391_line)) || (!__tmp391_last && __tmp391_line != null))
                        {
                            __out.Append(__tmp391_line);
                            __tmp389_outputWritten = true;
                        }
                        if (!__tmp391_last) __out.AppendLine(true);
                    }
                }
                string __tmp392_line = ".Compilation."; //541:59
                if (!string.IsNullOrEmpty(__tmp392_line))
                {
                    __out.Append(__tmp392_line);
                    __tmp389_outputWritten = true;
                }
                StringBuilder __tmp393 = new StringBuilder();
                __tmp393.Append(Properties.LanguageClassName);
                using(StreamReader __tmp393Reader = new StreamReader(this.__ToStream(__tmp393.ToString())))
                {
                    bool __tmp393_last = __tmp393Reader.EndOfStream;
                    while(!__tmp393_last)
                    {
                        string __tmp393_line = __tmp393Reader.ReadLine();
                        __tmp393_last = __tmp393Reader.EndOfStream;
                        if ((__tmp393_last && !string.IsNullOrEmpty(__tmp393_line)) || (!__tmp393_last && __tmp393_line != null))
                        {
                            __out.Append(__tmp393_line);
                            __tmp389_outputWritten = true;
                        }
                        if (!__tmp393_last) __out.AppendLine(true);
                    }
                }
                string __tmp394_line = "Compiler(req.Text, \"\", inputDir, null, req.FileName);"; //541:102
                if (!string.IsNullOrEmpty(__tmp394_line))
                {
                    __out.Append(__tmp394_line);
                    __tmp389_outputWritten = true;
                }
                if (__tmp389_outputWritten) __out.AppendLine(true);
                if (__tmp389_outputWritten)
                {
                    __out.AppendLine(false); //541:155
                }
                __out.Append("                        compilation.Compile();"); //542:1
                __out.AppendLine(false); //542:47
            }
            __out.Append("						foreach (var diagnostic in compilation.GetDiagnostics())"); //544:1
            __out.AppendLine(false); //544:63
            __out.Append("						{"); //545:1
            __out.AppendLine(false); //545:8
            __out.Append("                            var diagSpan = diagnostic.Location.GetMappedLineSpan();"); //546:1
            __out.AppendLine(false); //546:84
            __out.Append("                            TextSpan span = new TextSpan();"); //547:1
            __out.AppendLine(false); //547:60
            __out.Append("							span.iStartLine = diagSpan.StartLinePosition.Line;"); //548:1
            __out.AppendLine(false); //548:58
            __out.Append("							span.iEndLine = diagSpan.EndLinePosition.Line;"); //549:1
            __out.AppendLine(false); //549:54
            __out.Append("							span.iStartIndex = diagSpan.StartLinePosition.Character;"); //550:1
            __out.AppendLine(false); //550:64
            __out.Append("							span.iEndIndex = diagSpan.EndLinePosition.Character;"); //551:1
            __out.AppendLine(false); //551:60
            __out.Append("							Severity severity = Severity.Error;"); //552:1
            __out.AppendLine(false); //552:43
            __out.Append("							switch (diagnostic.Severity)"); //553:1
            __out.AppendLine(false); //553:36
            __out.Append("							{"); //554:1
            __out.AppendLine(false); //554:9
            __out.Append("								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Error:"); //555:1
            __out.AppendLine(false); //555:69
            __out.Append("									severity = Severity.Error;"); //556:1
            __out.AppendLine(false); //556:36
            __out.Append("									break;"); //557:1
            __out.AppendLine(false); //557:16
            __out.Append("								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Warning:"); //558:1
            __out.AppendLine(false); //558:71
            __out.Append("									severity = Severity.Warning;"); //559:1
            __out.AppendLine(false); //559:38
            __out.Append("									break;"); //560:1
            __out.AppendLine(false); //560:16
            __out.Append("								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Info:"); //561:1
            __out.AppendLine(false); //561:68
            __out.Append("									severity = Severity.Hint;"); //562:1
            __out.AppendLine(false); //562:35
            __out.Append("									break;"); //563:1
            __out.AppendLine(false); //563:16
            __out.Append("							}"); //564:1
            __out.AppendLine(false); //564:9
            __out.Append("                            string msg = Compiler.Diagnostics.DiagnosticFormatter.Instance.Format(diagnostic);"); //565:1
            __out.AppendLine(false); //565:111
            __out.Append("							req.Sink.AddError(req.FileName, msg, span, severity);"); //566:1
            __out.AppendLine(false); //566:61
            __out.Append("						}"); //567:1
            __out.AppendLine(false); //567:8
            __out.Append("						break;"); //568:1
            __out.AppendLine(false); //568:13
            __out.Append("				}"); //569:1
            __out.AppendLine(false); //569:6
            __out.Append("			}"); //570:1
            __out.AppendLine(false); //570:5
            __out.Append("			catch(Exception ex)"); //571:1
            __out.AppendLine(false); //571:23
            __out.Append("			{"); //572:1
            __out.AppendLine(false); //572:5
            __out.Append("				req.Sink.AddError(req.FileName, \"Error while parsing source: \"+ex.ToString(), new TextSpan(), Severity.Error);"); //573:1
            __out.AppendLine(false); //573:115
            __out.Append("			}"); //574:1
            __out.AppendLine(false); //574:5
            bool __tmp396_outputWritten = false;
            string __tmp397_line = "            return new "; //575:1
            if (!string.IsNullOrEmpty(__tmp397_line))
            {
                __out.Append(__tmp397_line);
                __tmp396_outputWritten = true;
            }
            StringBuilder __tmp398 = new StringBuilder();
            __tmp398.Append(Properties.LanguageClassName);
            using(StreamReader __tmp398Reader = new StreamReader(this.__ToStream(__tmp398.ToString())))
            {
                bool __tmp398_last = __tmp398Reader.EndOfStream;
                while(!__tmp398_last)
                {
                    string __tmp398_line = __tmp398Reader.ReadLine();
                    __tmp398_last = __tmp398Reader.EndOfStream;
                    if ((__tmp398_last && !string.IsNullOrEmpty(__tmp398_line)) || (!__tmp398_last && __tmp398_line != null))
                    {
                        __out.Append(__tmp398_line);
                        __tmp396_outputWritten = true;
                    }
                    if (!__tmp398_last) __out.AppendLine(true);
                }
            }
            string __tmp399_line = "LanguageAuthoringScope();"; //575:54
            if (!string.IsNullOrEmpty(__tmp399_line))
            {
                __out.Append(__tmp399_line);
                __tmp396_outputWritten = true;
            }
            if (__tmp396_outputWritten) __out.AppendLine(true);
            if (__tmp396_outputWritten)
            {
                __out.AppendLine(false); //575:79
            }
            __out.Append("        }"); //576:1
            __out.AppendLine(false); //576:10
            __out.Append("    }"); //577:1
            __out.AppendLine(false); //577:6
            bool __tmp401_outputWritten = false;
            string __tmp402_line = "	public class "; //578:1
            if (!string.IsNullOrEmpty(__tmp402_line))
            {
                __out.Append(__tmp402_line);
                __tmp401_outputWritten = true;
            }
            StringBuilder __tmp403 = new StringBuilder();
            __tmp403.Append(Properties.LanguageClassName);
            using(StreamReader __tmp403Reader = new StreamReader(this.__ToStream(__tmp403.ToString())))
            {
                bool __tmp403_last = __tmp403Reader.EndOfStream;
                while(!__tmp403_last)
                {
                    string __tmp403_line = __tmp403Reader.ReadLine();
                    __tmp403_last = __tmp403Reader.EndOfStream;
                    if ((__tmp403_last && !string.IsNullOrEmpty(__tmp403_line)) || (!__tmp403_last && __tmp403_line != null))
                    {
                        __out.Append(__tmp403_line);
                        __tmp401_outputWritten = true;
                    }
                    if (!__tmp403_last) __out.AppendLine(true);
                }
            }
            string __tmp404_line = "LanguageSource : Microsoft.VisualStudio.Package.Source"; //578:45
            if (!string.IsNullOrEmpty(__tmp404_line))
            {
                __out.Append(__tmp404_line);
                __tmp401_outputWritten = true;
            }
            if (__tmp401_outputWritten) __out.AppendLine(true);
            if (__tmp401_outputWritten)
            {
                __out.AppendLine(false); //578:99
            }
            __out.Append("    {"); //579:1
            __out.AppendLine(false); //579:6
            bool __tmp406_outputWritten = false;
            string __tmp407_line = "        public "; //580:1
            if (!string.IsNullOrEmpty(__tmp407_line))
            {
                __out.Append(__tmp407_line);
                __tmp406_outputWritten = true;
            }
            StringBuilder __tmp408 = new StringBuilder();
            __tmp408.Append(Properties.LanguageClassName);
            using(StreamReader __tmp408Reader = new StreamReader(this.__ToStream(__tmp408.ToString())))
            {
                bool __tmp408_last = __tmp408Reader.EndOfStream;
                while(!__tmp408_last)
                {
                    string __tmp408_line = __tmp408Reader.ReadLine();
                    __tmp408_last = __tmp408Reader.EndOfStream;
                    if ((__tmp408_last && !string.IsNullOrEmpty(__tmp408_line)) || (!__tmp408_last && __tmp408_line != null))
                    {
                        __out.Append(__tmp408_line);
                        __tmp406_outputWritten = true;
                    }
                    if (!__tmp408_last) __out.AppendLine(true);
                }
            }
            string __tmp409_line = "LanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)"; //580:46
            if (!string.IsNullOrEmpty(__tmp409_line))
            {
                __out.Append(__tmp409_line);
                __tmp406_outputWritten = true;
            }
            if (__tmp406_outputWritten) __out.AppendLine(true);
            if (__tmp406_outputWritten)
            {
                __out.AppendLine(false); //580:130
            }
            __out.Append("            : base(service, textLines, colorizer)"); //581:1
            __out.AppendLine(false); //581:50
            __out.Append("        {"); //582:1
            __out.AppendLine(false); //582:10
            __out.Append("        }"); //583:1
            __out.AppendLine(false); //583:10
            __out.Append("    }"); //584:1
            __out.AppendLine(false); //584:6
            bool __tmp411_outputWritten = false;
            string __tmp412_line = "    public class "; //585:1
            if (!string.IsNullOrEmpty(__tmp412_line))
            {
                __out.Append(__tmp412_line);
                __tmp411_outputWritten = true;
            }
            StringBuilder __tmp413 = new StringBuilder();
            __tmp413.Append(Properties.LanguageClassName);
            using(StreamReader __tmp413Reader = new StreamReader(this.__ToStream(__tmp413.ToString())))
            {
                bool __tmp413_last = __tmp413Reader.EndOfStream;
                while(!__tmp413_last)
                {
                    string __tmp413_line = __tmp413Reader.ReadLine();
                    __tmp413_last = __tmp413Reader.EndOfStream;
                    if ((__tmp413_last && !string.IsNullOrEmpty(__tmp413_line)) || (!__tmp413_last && __tmp413_line != null))
                    {
                        __out.Append(__tmp413_line);
                        __tmp411_outputWritten = true;
                    }
                    if (!__tmp413_last) __out.AppendLine(true);
                }
            }
            string __tmp414_line = "LanguageViewFilter : ViewFilter"; //585:48
            if (!string.IsNullOrEmpty(__tmp414_line))
            {
                __out.Append(__tmp414_line);
                __tmp411_outputWritten = true;
            }
            if (__tmp411_outputWritten) __out.AppendLine(true);
            if (__tmp411_outputWritten)
            {
                __out.AppendLine(false); //585:79
            }
            __out.Append("    {"); //586:1
            __out.AppendLine(false); //586:6
            bool __tmp416_outputWritten = false;
            string __tmp417_line = "        public "; //587:1
            if (!string.IsNullOrEmpty(__tmp417_line))
            {
                __out.Append(__tmp417_line);
                __tmp416_outputWritten = true;
            }
            StringBuilder __tmp418 = new StringBuilder();
            __tmp418.Append(Properties.LanguageClassName);
            using(StreamReader __tmp418Reader = new StreamReader(this.__ToStream(__tmp418.ToString())))
            {
                bool __tmp418_last = __tmp418Reader.EndOfStream;
                while(!__tmp418_last)
                {
                    string __tmp418_line = __tmp418Reader.ReadLine();
                    __tmp418_last = __tmp418Reader.EndOfStream;
                    if ((__tmp418_last && !string.IsNullOrEmpty(__tmp418_line)) || (!__tmp418_last && __tmp418_line != null))
                    {
                        __out.Append(__tmp418_line);
                        __tmp416_outputWritten = true;
                    }
                    if (!__tmp418_last) __out.AppendLine(true);
                }
            }
            string __tmp419_line = "LanguageViewFilter(CodeWindowManager mgr, IVsTextView view)"; //587:46
            if (!string.IsNullOrEmpty(__tmp419_line))
            {
                __out.Append(__tmp419_line);
                __tmp416_outputWritten = true;
            }
            if (__tmp416_outputWritten) __out.AppendLine(true);
            if (__tmp416_outputWritten)
            {
                __out.AppendLine(false); //587:105
            }
            __out.Append("            : base(mgr, view)"); //588:1
            __out.AppendLine(false); //588:30
            __out.Append("        {"); //589:1
            __out.AppendLine(false); //589:10
            __out.Append("        }"); //590:1
            __out.AppendLine(false); //590:10
            __out.Append("        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)"); //591:1
            __out.AppendLine(false); //591:150
            __out.Append("        {"); //592:1
            __out.AppendLine(false); //592:10
            __out.Append("            if (guidCmdGroup == typeof(VsCommands2K).GUID)"); //593:1
            __out.AppendLine(false); //593:59
            __out.Append("            {"); //594:1
            __out.AppendLine(false); //594:14
            __out.Append("                VsCommands2K cmd = (VsCommands2K)nCmdId;"); //595:1
            __out.AppendLine(false); //595:57
            __out.Append("                switch (cmd)"); //596:1
            __out.AppendLine(false); //596:29
            __out.Append("                {"); //597:1
            __out.AppendLine(false); //597:18
            __out.Append("                    case VsCommands2K.UP:"); //598:1
            __out.AppendLine(false); //598:42
            __out.Append("                    case VsCommands2K.UP_EXT:"); //599:1
            __out.AppendLine(false); //599:46
            __out.Append("                    case VsCommands2K.UP_EXT_COL:"); //600:1
            __out.AppendLine(false); //600:50
            __out.Append("                    case VsCommands2K.DOWN:"); //601:1
            __out.AppendLine(false); //601:44
            __out.Append("                    case VsCommands2K.DOWN_EXT:"); //602:1
            __out.AppendLine(false); //602:48
            __out.Append("                    case VsCommands2K.DOWN_EXT_COL:"); //603:1
            __out.AppendLine(false); //603:52
            __out.Append("                        Source.OnCommand(TextView, cmd, '"); //604:1
            __out.Append("\\"); //604:58
            __out.Append("0');"); //604:59
            __out.AppendLine(false); //604:63
            __out.Append("                        return;"); //605:1
            __out.AppendLine(false); //605:32
            __out.Append("                }"); //606:1
            __out.AppendLine(false); //606:18
            __out.Append("            }"); //607:1
            __out.AppendLine(false); //607:14
            __out.Append("            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);"); //608:1
            __out.AppendLine(false); //608:105
            __out.Append("        }"); //609:1
            __out.AppendLine(false); //609:10
            __out.Append("    }"); //610:1
            __out.AppendLine(false); //610:6
            __out.Append("}"); //611:1
            __out.AppendLine(false); //611:2
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
