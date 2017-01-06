using MetaDslx.Compiler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Text
{
    /// <summary>
    /// Immutable representation of a line number and position within a source text.
    /// </summary>
    public class LinePosition : IEquatable<LinePosition>, IComparable<LinePosition>
    {
        /// <summary>
        /// A <see cref="LinePosition"/> that represents position 0 at line 0.
        /// </summary>
        public static LinePosition Zero => new LinePosition(0, 0);

        private readonly int _line;
        private readonly int _character;

        /// <summary>
        /// Initializes a new instance of a <see cref="LinePosition"/> with the given line and character.
        /// </summary>
        /// <param name="line">
        /// The line of the line position. The first line in a file is defined as line 0 (zero based line numbering).
        /// </param>
        /// <param name="character">
        /// The character position in the line.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="line"/> or <paramref name="character"/> is less than zero. </exception>
        public LinePosition(int line, int character)
        {
            if (line < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(line));
            }

            if (character < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(character));
            }

            _line = line;
            _character = character;
        }

        /// <summary>
        /// The line number. The first line in a file is defined as line 0 (zero based line numbering).
        /// </summary>
        public int Line
        {
            get { return _line; }
        }

        /// <summary>
        /// The character position within the line.
        /// </summary>
        public int Character
        {
            get { return _character; }
        }

        /// <summary>
        /// Determines whether two <see cref="LinePosition"/> are the same.
        /// </summary>
        /// <param name="other">The object to compare.</param>
        public bool Equals(LinePosition other)
        {
            return other.Line == this.Line && other.Character == this.Character;
        }

        /// <summary>
        /// Determines whether two <see cref="LinePosition"/> are the same.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        public override bool Equals(object obj)
        {
            return obj is LinePosition && Equals((LinePosition)obj);
        }

        /// <summary>
        /// Provides a hash function for <see cref="LinePosition"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Hash.Combine(Line, Character);
        }

        /// <summary>
        /// Provides a string representation for <see cref="LinePosition"/>.
        /// </summary>
        /// <example>0,10</example>
        public override string ToString()
        {
            return Line + "," + Character;
        }

        public int CompareTo(LinePosition other)
        {
            int result = _line.CompareTo(other._line);
            return (result != 0) ? result : _character.CompareTo(other.Character);
        }

    }
}
