// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using MetaDslx.Compiler.Diagnostics;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Diagnostics
{
    public class SyntaxDiagnosticInfo : DiagnosticInfo
    {
        public int Offset { get; }
        public int Width { get; }

        internal SyntaxDiagnosticInfo(MessageProvider messageProvider, int offset, int width, int code, params object[] args)
            : base(messageProvider, code, args)
        {
            Debug.Assert(width >= 0);
            this.Offset = offset;
            this.Width = width;
        }

        internal SyntaxDiagnosticInfo(MessageProvider messageProvider, int offset, int width, int code)
            : this(messageProvider, offset, width, code, EmptyCollections.ObjectArray)
        {
        }

        internal SyntaxDiagnosticInfo(MessageProvider messageProvider, int code, params object[] args)
            : this(messageProvider, 0, 0, code, args)
        {
        }

        internal SyntaxDiagnosticInfo(MessageProvider messageProvider, int code)
            : this(messageProvider, 0, 0, code)
        {
        }

        private SyntaxDiagnosticInfo(SyntaxDiagnosticInfo original, DiagnosticSeverity overriddenSeverity)
            : base(original, overriddenSeverity)
        {
            this.Offset = original.Offset;
            this.Width = original.Width;
        }

        public virtual SyntaxDiagnosticInfo WithOffset(int offset)
        {
            return new SyntaxDiagnosticInfo(this.MessageProvider, offset, this.Width, this.Code, this.Arguments);
        }

        public override DiagnosticInfo WithSeverity(DiagnosticSeverity overriddenSeverity)
        {
            if (this.Severity != overriddenSeverity) return new SyntaxDiagnosticInfo(this, overriddenSeverity);
            else return this;
        }
    }
}
