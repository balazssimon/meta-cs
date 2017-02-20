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

        internal SyntaxDiagnosticInfo(int offset, int width, ErrorCode code, params object[] args)
            : base(code, args)
        {
            Debug.Assert(width >= 0);
            this.Offset = offset;
            this.Width = width;
        }

        internal SyntaxDiagnosticInfo(int offset, int width, ErrorCode code)
            : this(offset, width, code, EmptyCollections.ObjectArray)
        {
        }

        internal SyntaxDiagnosticInfo(ErrorCode code, params object[] args)
            : this(0, 0, code, args)
        {
        }

        internal SyntaxDiagnosticInfo(ErrorCode code)
            : this(0, 0, code)
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
            return new SyntaxDiagnosticInfo(offset, this.Width, this.Code, this.Arguments);
        }

        public override DiagnosticInfo WithSeverity(DiagnosticSeverity overriddenSeverity)
        {
            if (this.Severity != overriddenSeverity) return new SyntaxDiagnosticInfo(this, overriddenSeverity);
            else return this;
        }
    }
}
