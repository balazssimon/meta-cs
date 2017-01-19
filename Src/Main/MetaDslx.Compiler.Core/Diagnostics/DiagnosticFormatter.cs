using MetaDslx.Compiler.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Diagnostics
{
    /// <summary>
    /// Formats <see cref="Diagnostic"/> messages.
    /// </summary>
    public class DiagnosticFormatter
    {
        /// <summary>
        /// Formats the <see cref="Diagnostic"/> message using the optional <see cref="IFormatProvider"/>.
        /// </summary>
        /// <param name="diagnostic">The diagnostic.</param>
        /// <param name="formatter">The formatter; or null to use the default formatter.</param>
        /// <returns>The formatted message.</returns>
        public virtual string Format(Diagnostic diagnostic, IFormatProvider formatter = null)
        {
            if (diagnostic == null)
            {
                throw new ArgumentNullException(nameof(diagnostic));
            }

            switch (diagnostic.Location.Kind)
            {
                case LocationKind.SourceFile:
                case LocationKind.ExternalFile:
                    var span = diagnostic.Location.GetLineSpan();
                    var mappedSpan = diagnostic.Location.GetMappedLineSpan();
                    if (!span.IsValid || !mappedSpan.IsValid)
                    {
                        goto default;
                    }

                    string path, basePath;
                    if (mappedSpan.HasMappedPath)
                    {
                        path = mappedSpan.Path;
                        basePath = span.Path;
                    }
                    else
                    {
                        path = span.Path;
                        basePath = null;
                    }

                    return string.Format(formatter, "{0}{1}: {2}: {3}",
                                         FormatSourcePath(path, basePath, formatter),
                                         FormatSourceSpan(mappedSpan.Span, formatter),
                                         GetMessagePrefix(diagnostic),
                                         diagnostic.Info.GetMessage());

                default:
                    return string.Format(formatter, "{0}: {1}",
                                         GetMessagePrefix(diagnostic),
                                         diagnostic.Info.GetMessage());
            }
        }

        protected virtual string FormatSourcePath(string path, string basePath, IFormatProvider formatter)
        {
            // ignore base path
            return path;
        }

        protected virtual string FormatSourceSpan(LinePositionSpan span, IFormatProvider formatter)
        {
            return string.Format("({0},{1})", span.Start.Line + 1, span.Start.Character + 1);
        }

        protected string GetMessagePrefix(Diagnostic diagnostic)
        {
            string prefix;
            switch (diagnostic.Severity)
            {
                case DiagnosticSeverity.Hidden:
                    prefix = "hidden";
                    break;
                case DiagnosticSeverity.Info:
                    prefix = "info";
                    break;
                case DiagnosticSeverity.Warning:
                    prefix = "warning";
                    break;
                case DiagnosticSeverity.Error:
                    prefix = "error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(diagnostic), "Unexpected diagnostic severity:" + diagnostic.Severity);
            }

            return string.Format("{0} {1}", prefix, diagnostic.Id);
        }

        public static readonly DiagnosticFormatter Instance = new DiagnosticFormatter();
    }

}
