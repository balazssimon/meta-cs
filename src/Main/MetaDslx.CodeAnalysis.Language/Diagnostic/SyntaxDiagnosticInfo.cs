﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Roslyn.Utilities;

namespace Microsoft.CodeAnalysis.CSharp
{
    public class SyntaxDiagnosticInfo : LanguageDiagnosticInfo
    {
        static SyntaxDiagnosticInfo()
        {
            ObjectBinder.RegisterTypeReader(typeof(SyntaxDiagnosticInfo), r => new SyntaxDiagnosticInfo(r));
        }

        internal readonly int Offset;
        internal readonly int Width;

        internal SyntaxDiagnosticInfo(int offset, int width, ErrorCode code, params object[] args)
            : base(code, args)
        {
            Debug.Assert(width >= 0);
            this.Offset = offset;
            this.Width = width;
        }

        internal SyntaxDiagnosticInfo(int offset, int width, ErrorCode code)
            : this(offset, width, code, Array.Empty<object>())
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

        public SyntaxDiagnosticInfo WithOffset(int offset)
        {
            return new SyntaxDiagnosticInfo(offset, this.Width, this.ErrorCode, this.Arguments);
        }

        #region Serialization

        protected override void WriteTo(ObjectWriter writer)
        {
            base.WriteTo(writer);
            writer.WriteInt32(this.Offset);
            writer.WriteInt32(this.Width);
        }

        protected SyntaxDiagnosticInfo(ObjectReader reader)
            : base(reader)
        {
            this.Offset = reader.ReadInt32();
            this.Width = reader.ReadInt32();
        }

        #endregion
    }
}
