using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Antlr4.Runtime;
using System.Drawing;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;

using VsCommands2K = Microsoft.VisualStudio.VSConstants.VSStd2KCmdID;

namespace MetaDslx.Languages.Soal.VisualStudio
{
    public class SoalLanguageAuthoringScope : AuthoringScope
    {
        public override string GetDataTipText(int line, int col, out TextSpan span)
        {
            span = new TextSpan();
            return null;
        }
        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info, ParseReason reason)
        {
            return null;
        }
        public override Methods GetMethods(int line, int col, string name)
        {
            return null;
        }
        public override string Goto(Microsoft.VisualStudio.VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)
        {
            span = new TextSpan();
            return null;
        }
    }
	public class SoalLanguageColorizer : Colorizer
    {
        public SoalLanguageColorizer(LanguageService svc, IVsTextLines buffer, IScanner scanner)
            : base(svc, buffer, scanner)
        {
        }
        #region IVsColorizer Members
        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint[] attrs)
        {
            if (attrs == null) return state;
            int linepos = 0;
            // Must initialize the colors in all cases, otherwise you get 
            // random color junk on the screen.
            for (linepos = 0; linepos < attrs.Length; linepos++)
                attrs[linepos] = (uint)TokenColor.Text;
            if (this.Scanner != null)
            {
                try
                {
                    string text = Marshal.PtrToStringUni(ptr, length);
                    this.Scanner.SetSource(text, 0);
                    TokenInfo tokenInfo = new TokenInfo();
                    tokenInfo.EndIndex = -1;
                    while (this.Scanner.ScanTokenAndProvideInfoAboutIt(tokenInfo, ref state))
                    {
                        for (linepos = tokenInfo.StartIndex; linepos <= tokenInfo.EndIndex; linepos++)
                        {
                            if (linepos >= 0 && linepos < attrs.Length)
                            {
                                attrs[linepos] = (uint)tokenInfo.Color;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    // Ignore exceptions
                }
            }
            return state;
        }
        public override int GetStartState(out int piStartState)
        {
            piStartState = 0;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        public override int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)
        {
            string text = Marshal.PtrToStringUni(pText, iLength);
            if (text != null)
            {
                this.Scanner.SetSource(text, 0);
                ((SoalLanguageScanner)this.Scanner).ScanLine(ref iState);
            }
            return iState;
        }
        public override int GetStateMaintenanceFlag(out int pfFlag)
        {
            pfFlag = 1;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        #endregion
    }
    public abstract class SoalLanguageConfigBase
    {
        private static SoalLanguageConfig instance = null;
        public static SoalLanguageConfig Instance
        {
            get 
            {
                if (instance == null)
                {
					// If there is a compile error in the following line, create a class SoalLanguageConfig
					// which is a subclass of SoalLanguageConfigBase
                    instance = new SoalLanguageConfig();
                }
                return instance;
            }
        }
        private List<SoalLanguageColorableItem> colorableItems = new List<SoalLanguageColorableItem>();
        public IList<SoalLanguageColorableItem> ColorableItems
        {
            get { return colorableItems; }
        }
        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor)
        {
            return CreateColor(name, type, foregroundColor, false, false);
        }
        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex)
        {
            return CreateColor(name, type, foregroundIndex, false, false);
        }
        protected TokenColor CreateColor(string name, TokenType type, Color foregroundColor, bool bold, bool strikethrough)
        {
            colorableItems.Add(new SoalLanguageColorableItem(name, type, (COLORINDEX)(-1), COLORINDEX.CI_USERTEXT_BK, foregroundColor, Color.White, bold, strikethrough));
            return (TokenColor)colorableItems.Count;
        }
        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, bool bold, bool strikethrough)
        {
            colorableItems.Add(new SoalLanguageColorableItem(name, type, foregroundIndex, COLORINDEX.CI_USERTEXT_BK, Color.Black, Color.White, bold, strikethrough));
            return (TokenColor)colorableItems.Count;
        }
        protected TokenColor CreateColor(string name, TokenType type, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)
        {
            colorableItems.Add(new SoalLanguageColorableItem(name, type, foregroundIndex, backgroundIndex, foregroundColor, backgroundColor, bold, strikethrough));
            return (TokenColor)colorableItems.Count;
        }
    }
    public class SoalLanguageColorableItem : IVsColorableItem, IVsHiColorItem
    {
        // Indicates that the returned RGB value is really an index
        // into a predefined list of colors.
        private const uint COLOR_INDEXED = 0x01000000;
        public string DisplayName { get; private set; }
        public TokenType TokenType { get; private set; }
        public COLORINDEX BackgroundIndex { get; private set; }
        public COLORINDEX ForegroundIndex { get; private set; }
        public uint BackgroundColor { get; private set; }
        public uint ForegroundColor { get; private set; }
        public uint FontFlags { get; private set; }
        public SoalLanguageColorableItem(string displayName, TokenType tokenType, COLORINDEX foregroundIndex, COLORINDEX backgroundIndex, Color foregroundColor, Color backgroundColor, bool bold, bool strikethrough)
        {
            this.DisplayName = displayName;
            this.TokenType = tokenType;
            this.BackgroundIndex = backgroundIndex;
            this.ForegroundIndex = foregroundIndex;
            this.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(backgroundColor);
            this.ForegroundColor = (uint)System.Drawing.ColorTranslator.ToWin32(foregroundColor);
            this.FontFlags = (uint)FONTFLAGS.FF_DEFAULT;
            if (bold)
                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_BOLD;
            if (strikethrough)
                this.FontFlags = this.FontFlags | (uint)FONTFLAGS.FF_STRIKETHROUGH;
        }
        #region IVsColorableItem Members
        public int GetDefaultColors(COLORINDEX[] piForeground, COLORINDEX[] piBackground)
        {
            if (null == piForeground)
            {
                throw new ArgumentNullException("piForeground");
            }
            if (0 == piForeground.Length)
            {
                throw new ArgumentOutOfRangeException("piForeground");
            }
            piForeground[0] = this.ForegroundIndex;
            if (null == piBackground)
            {
                throw new ArgumentNullException("piBackground");
            }
            if (0 == piBackground.Length)
            {
                throw new ArgumentOutOfRangeException("piBackground");
            }
            piBackground[0] = this.BackgroundIndex;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        public int GetDefaultFontFlags(out uint pdwFontFlags)
        {
            pdwFontFlags = this.FontFlags;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        public int GetDisplayName(out string pbstrName)
        {
            pbstrName = this.DisplayName;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        public int GetColorData(int cdElement, out uint pcrColor)
        {
            int retval = VSConstants.E_NOTIMPL;
            pcrColor = 0;
            switch ((__tagVSCOLORDATA)cdElement)
            {
                case __tagVSCOLORDATA.CD_BACKGROUND:
                    pcrColor = this.BackgroundIndex > 0 ?
                                   (uint)this.BackgroundIndex | COLOR_INDEXED
                                   : this.BackgroundColor;
                    retval = VSConstants.S_OK;
                    break;
                case __tagVSCOLORDATA.CD_FOREGROUND:
                case __tagVSCOLORDATA.CD_LINECOLOR:
                    pcrColor = this.ForegroundIndex > 0 ?
                                   (uint)this.ForegroundIndex | COLOR_INDEXED
                                   : this.ForegroundColor;
                    retval = VSConstants.S_OK;
                    break;
                default:
                    retval = VSConstants.E_INVALIDARG;
                    break;
            }
            return retval;
        }
        #endregion
    }
    [ComVisible(true)]
    [Guid(SoalLanguageConfig.SoalGeneratorServiceGuid)]
    [ProvideObject(typeof(SoalGeneratorService), RegisterUsing = RegistrationMethod.CodeBase)]
    [CodeGeneratorRegistration(typeof(SoalGeneratorService), SoalLanguageConfig.GeneratorName, "{fae04ec1-301f-11d3-bf4b-00c04f79efbc}", GeneratorRegKeyName = SoalLanguageConfig.FileExtension)]
    [CodeGeneratorRegistration(typeof(SoalGeneratorService), SoalLanguageConfig.GeneratorServiceName, "{fae04ec1-301f-11d3-bf4b-00c04f79efbc}", GeneratorRegKeyName = SoalLanguageConfig.GeneratorName, GeneratesDesignTimeSource = true)]
    public class SoalGeneratorService : VsSingleFileGenerator
    {
        protected override SingleFileGenerator CreateGenerator(string inputFilePath, string inputFileContents, string defaultNamespace)
		{
			// If there is a compile error in the following line, create a class SoalGenerator
			// which is a subclass of SingleFileGenerator
			return new SoalGenerator(inputFilePath, inputFileContents, defaultNamespace);
		}

        public override string GetDefaultFileExtension()
        {
            return SoalGenerator.DefaultExtension;
        }
    }
    public class SoalLanguageScanner : IScanner
    {
        private int currentOffset;
        private string currentLine;
        private MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer lexer;
        private MetaDslx.Languages.Soal.Syntax.SoalSyntaxFacts syntaxFacts;
        private Dictionary<LanguageScannerState, int> inverseStates;
        private Dictionary<int, LanguageScannerState> states;
        private int lastState;
        public SoalLanguageScanner()
        {
            this.inverseStates = new Dictionary<LanguageScannerState, int>();
            this.states = new Dictionary<int, LanguageScannerState>();
            this.lastState = 0;
            this.syntaxFacts = MetaDslx.Languages.Soal.Syntax.SoalSyntaxFacts.Instance;
        }
        private void LoadState(int state, MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer lexer)
        {
            LanguageScannerState value = default(LanguageScannerState);
            this.states.TryGetValue(state, out value);
            value.Restore(lexer);
        }
        private int SaveState(MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer lexer)
        {
            int result = 0;
            LanguageScannerState state = new LanguageScannerState(lexer);
            if (!this.inverseStates.TryGetValue(state, out result))
            {
                result = ++lastState;
                this.states.Add(result, state);
                this.inverseStates.Add(state, result);
            }
            return result;
        }
        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            try
            {
                if (this.lexer == null)
                {
                    this.lexer = new MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer(new AntlrInputStream(this.currentLine + "\r\n"));
                }
                this.LoadState(state, this.lexer);
                IToken token = this.lexer.NextToken();
                int tokenType = (int)this.syntaxFacts.GetTokenKind(token.Type);
                if (tokenType == 0)
                {
                    tokenType = (int)this.syntaxFacts.GetModeTokenKind(this.lexer.CurrentMode);
                }
                if (tokenType >= 0 && tokenType < SoalLanguageConfig.Instance.ColorableItems.Count)
                {
                    SoalLanguageColorableItem colorItem = SoalLanguageConfig.Instance.ColorableItems[tokenType];
                    tokenInfo.Token = token.Type;
                    tokenInfo.Type = colorItem.TokenType;
                    tokenInfo.Color = (TokenColor)tokenType;
                    tokenInfo.Trigger = TokenTriggers.None;
                }
                else
                {
                    tokenInfo.Token = token.Type;
                    tokenInfo.Type = TokenType.Text;
                    tokenInfo.Color = TokenColor.Text;
                    tokenInfo.Trigger = TokenTriggers.None;
                }
                if (string.IsNullOrEmpty(token.Text) || this.currentOffset >= this.currentLine.Length)
                {
                    return false;
                }
                tokenInfo.StartIndex = this.currentOffset;
                this.currentOffset += token.Text.Length;
                tokenInfo.EndIndex = this.currentOffset - 1;
                state = this.SaveState(lexer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SetSource(string source, int offset)
        {
            //if (this.currentOffset != offset || this.currentLine != source)
            {
                this.currentOffset = offset;
                this.currentLine = source;
                this.lexer = null;
            }
        }
        internal void ScanLine(ref int state)
        {
            while (this.ScanTokenAndProvideInfoAboutIt(new TokenInfo(), ref state)) ;
        }
        internal struct LanguageScannerState
        {
            public LanguageScannerState(MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer lexer)
            {
                this._mode = lexer.CurrentMode;
                this._modeStack = lexer.ModeStack.Count > 0 ? new List<int>(lexer.ModeStack) : null;
                this._type = lexer.Type;
                this._channel = lexer.Channel;
                this._state = lexer.State;
            }
            internal int _state;
            internal int _mode;
            internal List<int> _modeStack;
            internal int _type;
            internal int _channel;
            public void Restore(MetaDslx.Languages.Soal.Syntax.InternalSyntax.SoalLexer lexer)
            {
                lexer.CurrentMode = this._mode;
                lexer.ModeStack.Clear();
                if (this._modeStack != null)
                {
                    foreach (var item in this._modeStack)
                    {
                        lexer.ModeStack.Push(item);
                    }
                }
                lexer.Type = this._type;
                lexer.Channel = this._channel;
                lexer.State = this._state;
            }
            public override bool Equals(object obj)
            {
                LanguageScannerState rhs = (LanguageScannerState)obj;
                if (rhs._mode != this._mode) return false;
                if (rhs._type != this._type) return false;
                if (rhs._state != this._state) return false;
                if (rhs._channel != this._channel) return false;
                if (rhs._modeStack == null && this._modeStack != null) return false;
                if (rhs._modeStack != null && this._modeStack == null) return false;
                if (rhs._modeStack != null && this._modeStack != null)
                {
                    if (rhs._modeStack.Count != this._modeStack.Count) return false;
                    for (int i = 0; i < rhs._modeStack.Count; ++i)
                    {
                        if (rhs._modeStack[i] != this._modeStack[i]) return false;
                    }
                }
                return true;
            }
            public override int GetHashCode()
            {
                int result = 0;
                result ^= this._mode.GetHashCode();
                result ^= this._type.GetHashCode();
                result ^= this._state.GetHashCode();
                result ^= this._channel.GetHashCode();
                if (this._modeStack != null)
                {
                    result ^= this._modeStack.GetHashCode();
                }
                return result;
            }
        }
    }
    [ComVisible(true)]
    [Guid(SoalLanguageConfig.SoalLanguageServiceGuid)]
    public class SoalLanguageService : LanguageService
    {
        private LanguagePreferences preferences;
        private SoalLanguageScanner scanner;
        public SoalLanguageService()
        {
			// Creating the config instance
			SoalLanguageConfigBase.Instance.ToString();
        }
        public override string GetFormatFilterList()
        {
            return SoalLanguageConfig.FilterList;
        }
        public override LanguagePreferences GetLanguagePreferences()
        {
            if (preferences == null)
            {
                preferences = new LanguagePreferences(this.Site, typeof(SoalLanguageService).GUID, this.Name);
                preferences.Init();
            }
            return preferences;
        }
        public override IScanner GetScanner(IVsTextLines buffer)
        {
            if (scanner == null)
            {
                scanner = new SoalLanguageScanner();
            }
            return scanner;
        }
        public override Microsoft.VisualStudio.Package.Source CreateSource(IVsTextLines buffer)
        {
            return new SoalLanguageSource(this, buffer, this.GetColorizer(buffer));
        }
        #region Custom Colors
        public override int GetColorableItem(int index, out IVsColorableItem item)
        {
            if (index >= 0 && index < SoalLanguageConfig.Instance.ColorableItems.Count)
            {
                item = SoalLanguageConfig.Instance.ColorableItems[index];
                return Microsoft.VisualStudio.VSConstants.S_OK;
            }
            else
            {
                item = SoalLanguageConfig.Instance.ColorableItems[0];
                return Microsoft.VisualStudio.VSConstants.S_OK;
            }
        }
        public override int GetItemCount(out int count)
        {
            count = SoalLanguageConfig.Instance.ColorableItems.Count;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }
        #endregion
        public override void OnIdle(bool periodic)
        {
            // from IronPythonLanguage sample
            // this appears to be necessary to get a parse request with ParseReason = Check?
            SoalLanguageSource src = (SoalLanguageSource)GetSource(this.LastActiveTextView);
            if (src != null && src.LastParseTime >= Int32.MaxValue >> 12)
            {
                src.LastParseTime = 0;
            }
            base.OnIdle(periodic);
        }
        public override string Name
        {
            get { return SoalLanguageConfig.LanguageName; }
        }
        public override ViewFilter CreateViewFilter(CodeWindowManager mgr, IVsTextView newView)
        {
            return new SoalLanguageViewFilter(mgr, newView);
        }
        public override Colorizer GetColorizer(IVsTextLines buffer)
        {
            return new SoalLanguageColorizer(this, buffer, this.GetScanner(buffer));
        }
        public override AuthoringScope ParseSource(ParseRequest req)
        {
			try
			{
				SoalLanguageSource source = (SoalLanguageSource)this.GetSource(req.FileName);
				switch (req.Reason)
				{
					case ParseReason.Check:
						// This is where you perform your syntax highlighting.
						// Parse entire source as given in req.Text.
						// Store results in the AuthoringScope object.
						string fileName = Path.GetFileName(req.FileName);
						string inputDir = Path.GetDirectoryName(req.FileName);
						var compilation = new MetaDslx.Languages.Soal.Compilation.SoalCompiler(req.Text, "", inputDir, null, req.FileName);
                        compilation.Compile();
						foreach (var diagnostic in compilation.GetDiagnostics())
						{
                            var diagSpan = diagnostic.Location.GetMappedLineSpan();
                            TextSpan span = new TextSpan();
							span.iStartLine = diagSpan.StartLinePosition.Line;
							span.iEndLine = diagSpan.EndLinePosition.Line;
							span.iStartIndex = diagSpan.StartLinePosition.Character;
							span.iEndIndex = diagSpan.EndLinePosition.Character;
							Severity severity = Severity.Error;
							switch (diagnostic.Severity)
							{
								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Error:
									severity = Severity.Error;
									break;
								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Warning:
									severity = Severity.Warning;
									break;
								case MetaDslx.Compiler.Diagnostics.DiagnosticSeverity.Info:
									severity = Severity.Hint;
									break;
							}
                            string msg = Compiler.Diagnostics.DiagnosticFormatter.Instance.Format(diagnostic);
							req.Sink.AddError(req.FileName, msg, span, severity);
						}
						break;
				}
			}
			catch(Exception ex)
			{
				req.Sink.AddError(req.FileName, "Error while parsing source: "+ex.ToString(), new TextSpan(), Severity.Error);
			}
            return new SoalLanguageAuthoringScope();
        }
    }
	public class SoalLanguageSource : Microsoft.VisualStudio.Package.Source
    {
        public SoalLanguageSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)
            : base(service, textLines, colorizer)
        {
        }
    }
    public class SoalLanguageViewFilter : ViewFilter
    {
        public SoalLanguageViewFilter(CodeWindowManager mgr, IVsTextView view)
            : base(mgr, view)
        {
        }
        public override void HandlePostExec(ref Guid guidCmdGroup, uint nCmdId, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut, bool bufferWasChanged)
        {
            if (guidCmdGroup == typeof(VsCommands2K).GUID)
            {
                VsCommands2K cmd = (VsCommands2K)nCmdId;
                switch (cmd)
                {
                    case VsCommands2K.UP:
                    case VsCommands2K.UP_EXT:
                    case VsCommands2K.UP_EXT_COL:
                    case VsCommands2K.DOWN:
                    case VsCommands2K.DOWN_EXT:
                    case VsCommands2K.DOWN_EXT_COL:
                        Source.OnCommand(TextView, cmd, '\0');
                        return;
                }
            }
            base.HandlePostExec(ref guidCmdGroup, nCmdId, nCmdexecopt, pvaIn, pvaOut, bufferWasChanged);
        }
    }
}

