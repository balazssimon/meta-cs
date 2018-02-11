﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;

namespace MetaDslx.Compiler.Text
{
    /// <summary>
    /// Represents the change to a span of text.
    /// </summary>
    public struct TextChangeRange : IEquatable<TextChangeRange>
    {
        /// <summary>
        /// The span of text before the edit which is being changed
        /// </summary>
        public TextSpan Span { get; }

        /// <summary>
        /// Width of the span after the edit.  A 0 here would represent a delete
        /// </summary>
        public int NewLength { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="TextChangeRange"/>.
        /// </summary>
        /// <param name="span"></param>
        /// <param name="newLength"></param>
        public TextChangeRange(TextSpan span, int newLength)
            : this()
        {
            if (newLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(newLength));
            }

            this.Span = span;
            this.NewLength = newLength;
        }

        /// <summary>
        /// Compares current instance of <see cref="TextChangeRange"/> to another.
        /// </summary>
        public bool Equals(TextChangeRange other)
        {
            return
                other.Span.Equals(this.Span) &&
                other.NewLength == this.NewLength;
        }

        /// <summary>
        /// Compares current instance of <see cref="TextChangeRange"/> to another.
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is TextChangeRange && Equals((TextChangeRange)obj);
        }

        /// <summary>
        /// Provides hash code for current instance of <see cref="TextChangeRange"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Hash.Combine(this.NewLength, this.Span.GetHashCode());
        }

        /// <summary>
        /// An empty set of changes.
        /// </summary>
        public static IReadOnlyList<TextChangeRange> NoChanges => EmptyCollections.ReadOnlyList<TextChangeRange>();

        /// <summary>
        /// Collapse a set of <see cref="TextChangeRange"/>s into a single encompassing range.  If
        /// the set of ranges provided is empty, an empty range is returned.
        /// </summary>
        public static TextChangeRange Collapse(IEnumerable<TextChangeRange> changes)
        {
            var diff = 0;
            var start = int.MaxValue;
            var end = 0;

            foreach (var change in changes)
            {
                diff += change.NewLength - change.Span.Length;

                if (change.Span.Start < start)
                {
                    start = change.Span.Start;
                }

                if (change.Span.End > end)
                {
                    end = change.Span.End;
                }
            }

            if (start > end)
            {
                // there were no changes.
                return default(TextChangeRange);
            }

            var combined = TextSpan.FromBounds(start, end);
            var newLen = combined.Length + diff;

            return new TextChangeRange(combined, newLen);
        }
    }
}