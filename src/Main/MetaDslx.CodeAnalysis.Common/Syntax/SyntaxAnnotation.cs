// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using Roslyn.Utilities;

namespace MetaDslx.CodeAnalysis
{
    /// <summary>
    /// A SyntaxAnnotation is used to annotate syntax elements with additional information. 
    /// 
    /// Since syntax elements are immutable, annotating them requires creating new instances of them
    /// with the annotations attached.
    /// </summary>
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    public sealed class SyntaxAnnotation : IObjectWritable, IEquatable<SyntaxAnnotation>
    {
        static SyntaxAnnotation()
        {
            ObjectBinder.RegisterTypeReader(typeof(SyntaxAnnotation), r => new SyntaxAnnotation(r));
        }

        /// <summary>
        /// A predefined syntax annotation that indicates whether the syntax element has elastic trivia.
        /// </summary>
        public static SyntaxAnnotation ElasticAnnotation { get; } = new SyntaxAnnotation();

        // use a value identity instead of object identity so a deserialized instance matches the original instance.
        private readonly long _id;
        private readonly object _data;
        private static long s_nextId;

        // use a value identity instead of object identity so a deserialized instance matches the original instance.
        public string Kind { get; }
        public string Data => _data is string ? (string)_data : _data.ToString();
        public object ObjectData => _data;

        public SyntaxAnnotation()
        {
            _id = System.Threading.Interlocked.Increment(ref s_nextId);
        }

        public SyntaxAnnotation(string kind)
            : this()
        {
            this.Kind = kind;
        }

        public SyntaxAnnotation(string kind, string data)
            : this(kind)
        {
            _data = data;
        }

        public SyntaxAnnotation(string kind, object data)
            : this(kind)
        {
            _data = data;
        }

        private SyntaxAnnotation(ObjectReader reader)
        {
            _id = reader.ReadInt64();
            this.Kind = reader.ReadString();
            _data = reader.ReadValue();
        }

        bool IObjectWritable.ShouldReuseInSerialization => true;

        void IObjectWritable.WriteTo(ObjectWriter writer)
        {
            writer.WriteInt64(_id);
            writer.WriteString(this.Kind);
            writer.WriteValue(_data);
        }

        private string GetDebuggerDisplay()
        {
            return string.Format("Annotation: Kind='{0}' Data='{1}'", this.Kind ?? "", this.Data ?? "");
        }

        public bool Equals(SyntaxAnnotation other)
        {
            return (object)other != null && _id == other._id;
        }

        public static bool operator ==(SyntaxAnnotation left, SyntaxAnnotation right)
        {
            if ((object)left == (object)right)
            {
                return true;
            }

            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(SyntaxAnnotation left, SyntaxAnnotation right)
        {
            if ((object)left == (object)right)
            {
                return false;
            }

            if ((object)left == null || (object)right == null)
            {
                return true;
            }

            return !left.Equals(right);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as SyntaxAnnotation);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
