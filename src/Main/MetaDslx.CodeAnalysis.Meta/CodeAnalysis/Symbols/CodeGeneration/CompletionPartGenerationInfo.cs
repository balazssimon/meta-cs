using MetaDslx.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaDslx.CodeAnalysis.Symbols.CodeGeneration
{
    public class CompletionPartGenerationInfo
    {
        public CompletionPartGenerationInfo(string containingTypeFullName, string name, string completeMethodName, CompleteMethodParameters completeMethodParameters, bool generateCompleteMethod, bool locked)
        {
            this.ContainingTypeFullName = containingTypeFullName;
            this.CompletionPartName = name;
            this.CompleteMethodName = completeMethodName;
            this.CompleteMethodParameters = completeMethodParameters;
            this.GenerateCompleteMethod = generateCompleteMethod;
            this.IsLocked = locked;
        }

        public string ContainingTypeFullName { get; private set; }
        public string CompletionPartName { get; private set; }
        public string StartCompletionPartName => this.IsLocked ? "Start" + CompletionPartName : CompletionPartName;
        public string FinishCompletionPartName => this.IsLocked ? "Finish" + CompletionPartName : CompletionPartName;
        public string CompleteMethodName { get; private set; }
        public virtual string CompleteMethodReturnType => "void";
        public CompleteMethodParameters CompleteMethodParameters { get; private set; }
        public bool IsLocked { get; private set; }
        public bool GenerateCompleteMethod { get; private set; }

        public string CompleteMethodParamList
        {
            get
            {
                var cb = CodeBuilder.GetInstance();
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.LocationOpt))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("SourceLocation locationOpt");
                }
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("DiagnosticBag diagnostics");
                }
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.CancellationToken))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("CancellationToken cancellationToken");
                }
                return cb.ToStringAndFree();
            }
        }

        public string CompleteMethodArgList
        {
            get
            {
                var cb = CodeBuilder.GetInstance();
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.LocationOpt))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("locationOpt");
                }
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.Diagnostics))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("diagnostics");
                }
                if (this.CompleteMethodParameters.HasFlag(CompleteMethodParameters.CancellationToken))
                {
                    if (cb.Length > 0) cb.Write(", ");
                    cb.Write("cancellationToken");
                }
                return cb.ToStringAndFree();
            }
        }
    }
}
