// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using MetaDslx.Compiler.Utilities;

namespace MetaDslx.Compiler.Diagnostics
{
    public class SyntaxDiagnosticInfo : DiagnosticInfo
    {
        static SyntaxDiagnosticInfo()
        {
            ObjectBinder.RegisterTypeReader(typeof(SyntaxDiagnosticInfo), r => new SyntaxDiagnosticInfo(r));
        }

        internal readonly int Offset;
        internal readonly int Width;

        internal SyntaxDiagnosticInfo(int offset, int width, DiagnosticDescriptor descriptor, params object[] args)
            : base(descriptor, args)
        {
            Debug.Assert(width >= 0);
            this.Offset = offset;
            this.Width = width;
        }

        internal SyntaxDiagnosticInfo(int offset, int width, DiagnosticDescriptor descriptor)
            : this(offset, width, descriptor, Array.Empty<object>())
        {
        }

        internal SyntaxDiagnosticInfo(DiagnosticDescriptor descriptor, params object[] args)
            : this(0, 0, descriptor, args)
        {
        }

        internal SyntaxDiagnosticInfo(DiagnosticDescriptor descriptor)
            : this(0, 0, descriptor)
        {
        }

        public SyntaxDiagnosticInfo WithOffset(int offset)
        {
            return new SyntaxDiagnosticInfo(offset, this.Width, this.Descriptor, this.Arguments);
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
