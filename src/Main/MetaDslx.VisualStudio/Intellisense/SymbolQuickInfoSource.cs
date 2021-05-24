using MetaDslx.CodeAnalysis;
using MetaDslx.CodeAnalysis.Symbols;
using MetaDslx.CodeAnalysis.Symbols.Metadata;
using MetaDslx.Modeling;
using MetaDslx.VisualStudio.Compilation;
using MetaDslx.VisualStudio.Editor;
using MetaDslx.VisualStudio.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Core.Imaging;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Language.StandardClassification;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Adornments;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SymbolKind = MetaDslx.CodeAnalysis.Symbols.SymbolKind;

namespace MetaDslx.VisualStudio.Intellisense
{
    public class SymbolQuickInfoSource : IAsyncQuickInfoSource
    {
        private readonly MetaDslxMefServices _mefServices;
        private readonly MetaDslxQuickInfoSourceProvider _provider; 
        private readonly ITextBuffer _textBuffer;
        private readonly BackgroundCompilation _backgroundCompilation;

        public SymbolQuickInfoSource(MetaDslxMefServices mefServices, MetaDslxQuickInfoSourceProvider provider, ITextBuffer textBuffer)
        {
            _mefServices = mefServices;
            _provider = provider;
            _textBuffer = textBuffer;
            _backgroundCompilation = BackgroundCompilation.GetOrCreate(mefServices, textBuffer);
        }

        public static SymbolQuickInfoSource GetOrCreate(MetaDslxMefServices mefServices, MetaDslxQuickInfoSourceProvider provider, ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(() => new SymbolQuickInfoSource(
                mefServices,
                provider,
                textBuffer
            ));
        }

        #region IDisposable Support
        private bool _isDisposed;
        public void Dispose()
        {
            if (!_isDisposed)
            {
                GC.SuppressFinalize(this);
                _isDisposed = true;
            }
        }
        #endregion

        public async Task<QuickInfoItem> GetQuickInfoItemAsync(IAsyncQuickInfoSession session, CancellationToken cancellationToken)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            if (Keyboard.Modifiers != ModifierKeys.Control)
            {
                var triggerPoint = session.GetTriggerPoint(_textBuffer.CurrentSnapshot);

                if (triggerPoint != null)
                {
                    var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
                    //var compilation = (LanguageCompilation)compilationSnapshot.Compilation;
                    var position = triggerPoint.Value.Position;
                    var symbols = compilationSnapshot.GetCompilationStepResult<CollectSymbolsResult>();
                    if (symbols != null)
                    {
                        foreach (var token in symbols.TokensWithSymbols)
                        {
                            if (token.Span.Contains(position))
                            {
                                var symbol = symbols.GetSymbol(token) as Symbol;
                                if (symbol != null)
                                {
                                    return await this.GetQuickInfoItemForSymbolAsync(symbol, token, cancellationToken);
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private async Task<QuickInfoItem> GetQuickInfoItemForSymbolAsync(Symbol symbol, SyntaxToken token, CancellationToken cancellationToken)
        {
            var compilationSnapshot = _backgroundCompilation.CompilationSnapshot;
            var compilation = (LanguageCompilation)compilationSnapshot.Compilation;
            var tokenSpan = _textBuffer.CurrentSnapshot.CreateTrackingSpan(new Span(token.Span.Start, token.Span.Length), SpanTrackingMode.EdgeInclusive);

            return await System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    var header = new List<ClassifiedTextRun>();
                    var containingSymbol = symbol.ContainingSymbol;
                    while (containingSymbol != null)
                    {
                        if (containingSymbol.Kind == SymbolKind.NetModule || string.IsNullOrWhiteSpace(containingSymbol.Name)) break;
                        header.Add(new ClassifiedTextRun(containingSymbol.Kind == SymbolKind.NamedType ? PredefinedClassificationTypeNames.SymbolDefinition : PredefinedClassificationTypeNames.Identifier, containingSymbol.Name + "."));
                        containingSymbol = containingSymbol.ContainingSymbol;
                    }
                    header.Reverse();
                    if (symbol is IModelSymbol modelSymbol && modelSymbol.ModelObject is IModelObject modelObject)
                    {
                        header.Insert(0, new ClassifiedTextRun(PredefinedClassificationTypeNames.Keyword, modelObject.MMetaClass.Name + " "));
                    }
                    header.Add(new ClassifiedTextRun(symbol.Kind == SymbolKind.NamedType ? PredefinedClassificationTypeNames.SymbolDefinition : PredefinedClassificationTypeNames.Identifier, symbol.Name));

                    var elm = new ContainerElement(
                        ContainerElementStyle.Wrapped,
                        new ImageElement(symbol.Kind == SymbolKind.Namespace ? StandardIcons.NamespaceIcon : symbol.Kind == SymbolKind.NamedType ? StandardIcons.ClassIcon : StandardIcons.PropertyIcon),
                        new ClassifiedTextElement(header));

                    if (symbol is DeclaredSymbol declaredSymbol)
                    {
                        var docComment = declaredSymbol.GetDocumentationCommentXml(cancellationToken: cancellationToken);
                        if (!string.IsNullOrWhiteSpace(docComment))
                        {
                            elm = new ContainerElement(
                                ContainerElementStyle.Stacked,
                                elm,
                                new ClassifiedTextElement(
                                    new ClassifiedTextRun(PredefinedClassificationTypeNames.Identifier, declaredSymbol.GetDocumentationCommentXml(cancellationToken: cancellationToken))
                                ));
                        }
                    }
                    return new QuickInfoItem(tokenSpan, elm);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex);
                    return null;
                }
            });
        }
    }
}
