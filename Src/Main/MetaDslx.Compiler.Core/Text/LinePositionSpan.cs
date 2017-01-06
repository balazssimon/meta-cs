using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Text
{
    /// <summary>
    /// Immutable span represented by a pair of line number and index within the line.
    /// </summary>
    public class LinePositionSpan : IEquatable<LinePositionSpan>
    {
        public static readonly LinePositionSpan Zero = new LinePositionSpan(LinePosition.Zero, LinePosition.Zero);

        private readonly LinePosition _start;
        private readonly LinePosition _end;

        /// <summary>
        /// Creates <see cref="LinePositionSpan"/>.
        /// </summary>
        /// <param name="start">Start position.</param>
        /// <param name="end">End position.</param>
        /// <exception cref="ArgumentException"><paramref name="end"/> precedes <paramref name="start"/>.</exception>
        public LinePositionSpan(LinePosition start, LinePosition end)
        {
            if (end.CompareTo(start) < 0)
            {
                throw new ArgumentException("End must not be less than start.", nameof(end));
            }

            _start = start;
            _end = end;
        }

        /// <summary>
        /// Gets the start position of the span.
        /// </summary>
        public LinePosition Start
        {
            get { return _start; }
        }

        /// <summary>
        /// Gets the end position of the span.
        /// </summary>
        public LinePosition End
        {
            get { return _end; }
        }

        public override bool Equals(object obj)
        {
            return obj is LinePositionSpan && Equals((LinePositionSpan)obj);
        }

        public bool Equals(LinePositionSpan other)
        {
            return _start.Equals(other._start)
                && _end.Equals(other._end);
        }

        public override int GetHashCode()
        {
            return Hash.Combine(_start.GetHashCode(), _end.GetHashCode());
        }

        /// <summary>
        /// Provides a string representation for <see cref="LinePositionSpan"/>.
        /// </summary>
        /// <example>(0,0)-(5,6)</example>
        public override string ToString()
        {
            return string.Format("({0})-({1})", _start, _end);
        }
    }
}
