﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Roslyn.Utilities;
using Word = System.UInt32;

namespace Roslyn.Utilities
{
    [DebuggerDisplay("{GetDebuggerDisplay(), nq}")]
    internal struct ExtensibleBitVector : IEquatable<ExtensibleBitVector>
    {
        private const Word ZeroWord = 0;
        private const int Log2BitsPerWord = 5;

        public const int BitsPerWord = 1 << Log2BitsPerWord;

        // Cannot expose the following two field publicly because this structure is mutable
        // and might become not null/empty, unless we restrict access to it.
        private static readonly Word[] s_emptyArray = Array.Empty<Word>();
        private static readonly ExtensibleBitVector s_nullValue = default;
        private static readonly ExtensibleBitVector s_emptyValue = new ExtensibleBitVector(0, s_emptyArray, 0);

        private Word _bits0;
        private Word[] _bits;
        private int _capacity;

        private ExtensibleBitVector(Word bits0, Word[] bits, int capacity)
        {
            int requiredWords = WordsForCapacity(capacity);
            Debug.Assert(requiredWords == 0 || requiredWords <= bits.Length);
            _bits0 = bits0;
            _bits = bits;
            _capacity = capacity;
            Check();
        }

        public bool Equals(ExtensibleBitVector other)
        {
            return _bits0 == other._bits0 && ArraysEqual(_bits, other._bits);
        }

        private static bool ArraysEqual(Word[] left, Word[] right)
        {
            if (left == right)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            int maxLength = Math.Max(left.Length, right.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }
            for (int i = maxLength; i < left.Length; i++)
            {
                if (left[i] != 0)
                {
                    return false;
                }
            }
            for (int i = maxLength; i < right.Length; i++)
            {
                if (right[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is ExtensibleBitVector && Equals((ExtensibleBitVector)obj);
        }

        public static bool operator ==(ExtensibleBitVector left, ExtensibleBitVector right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExtensibleBitVector left, ExtensibleBitVector right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            int bitsHash = _bits0.GetHashCode();

            if (_bits != null)
            {
                for (int i = 0; i < _bits.Length; i++)
                {
                    bitsHash = Hash.Combine(_bits[i].GetHashCode(), bitsHash);
                }
            }

            return Hash.Combine(_capacity, bitsHash);
        }

        private static int WordsForCapacity(int capacity)
        {
            if (capacity <= 0) return 0;
            int lastIndex = (capacity - 1) >> Log2BitsPerWord;
            return lastIndex;
        }

        public int Capacity => _capacity;

        [Conditional("DEBUG_BITARRAY")]
        private void Check()
        {
            Debug.Assert(_capacity == 0 || WordsForCapacity(_capacity) <= _bits.Length);
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (newCapacity > _capacity)
            {
                int requiredWords = WordsForCapacity(newCapacity);
                if (requiredWords > _bits.Length) Array.Resize(ref _bits, requiredWords);
                _capacity = newCapacity;
                Check();
            }
            Check();
        }

        public IEnumerable<Word> Words()
        {
            if (_capacity > 0)
            {
                yield return _bits0;
            }

            for (int i = 0; i < _bits?.Length; i++)
            {
                yield return _bits[i];
            }
        }

        public IEnumerable<int> TrueBits()
        {
            Check();
            if (_bits0 != 0)
            {
                for (int bit = 0; bit < BitsPerWord; bit++)
                {
                    Word mask = ((Word)1) << bit;
                    if ((_bits0 & mask) != 0)
                    {
                        if (bit >= _capacity) yield break;
                        yield return bit;
                    }
                }
            }
            for (int i = 0; i < _bits.Length; i++)
            {
                Word w = _bits[i];
                if (w != 0)
                {
                    for (int b = 0; b < BitsPerWord; b++)
                    {
                        Word mask = ((Word)1) << b;
                        if ((w & mask) != 0)
                        {
                            int bit = ((i + 1) << Log2BitsPerWord) | b;
                            if (bit >= _capacity) yield break;
                            yield return bit;
                        }
                    }
                }
            }
        }

        public bool HasSingleBit()
        {
            var trueBits = TrueBits().GetEnumerator();
            int index = 0;
            while (index < 2)
            {
                if (trueBits.MoveNext()) ++index;
                else break;
            }
            return index == 1;
        }

        public bool TryGetSingleBit(out int bit)
        {
            var trueBits = TrueBits().GetEnumerator();
            bit = 0;
            int index = 0;
            while (index < 2)
            {
                if (trueBits.MoveNext())
                {
                    bit = trueBits.Current;
                    ++index;
                }
                else
                {
                    break;
                }
            }
            return index == 1;
        }

        /// <summary>
        /// Create BitArray with at least the specified number of bits.
        /// </summary>
        public static ExtensibleBitVector Create(int bit)
        {
            var result = new ExtensibleBitVector();
            result[bit] = true;
            return result;
        }

        /// <summary>
        /// return a bit array with all bits set from index 0 through bitCount-1
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static ExtensibleBitVector AllSet(int capacity)
        {
            if (capacity == 0)
            {
                return Empty;
            }

            int requiredWords = WordsForCapacity(capacity);
            Word[] bits = (requiredWords == 0) ? s_emptyArray : new Word[requiredWords];
            int lastWord = requiredWords - 1;
            Word bits0 = ~ZeroWord;
            for (int j = 0; j < lastWord; j++)
                bits[j] = ~ZeroWord;
            int numTrailingBits = capacity & ((BitsPerWord) - 1);
            if (numTrailingBits > 0)
            {
                Debug.Assert(numTrailingBits <= BitsPerWord);
                Word lastBits = ~((~ZeroWord) << numTrailingBits);
                if (lastWord < 0)
                {
                    bits0 = lastBits;
                }
                else
                {
                    bits[lastWord] = lastBits;
                }
            }
            else if (requiredWords > 0)
            {
                bits[lastWord] = ~ZeroWord;
            }

            return new ExtensibleBitVector(bits0, bits, capacity);
        }

        /// <summary>
        /// Make a copy of a bit array.
        /// </summary>
        /// <returns></returns>
        public ExtensibleBitVector Clone()
        {
            return new ExtensibleBitVector(_bits0, (_bits == null) ? null : (_bits.Length == 0) ? s_emptyArray : (Word[])_bits.Clone(), _capacity);
        }

        /// <summary>
        /// Is the given bit array null?
        /// </summary>
        public bool IsNull
        {
            get
            {
                return _bits == null;
            }
        }

        public static ExtensibleBitVector Null => s_nullValue;

        public static ExtensibleBitVector Empty => s_emptyValue;

        public bool IsZero
        {
            get { return !this.IsNonZero; }
        }

        public bool IsNonZero
        {
            get { return this.TrueBits().Any(); }
        }

        /// <summary>
        /// Modify this bit vector by bitwise AND-ing each element with the other bit vector.
        /// For the purposes of the intersection, any bits beyond the current length will be treated as zeroes.
        /// Return true if any changes were made to the bits of this bit vector.
        /// </summary>
        public bool IntersectWith(in ExtensibleBitVector other)
        {
            bool anyChanged = false;
            int otherLength = other._bits.Length;
            var thisBits = _bits;
            int thisLength = thisBits.Length;

            if (otherLength > thisLength)
                otherLength = thisLength;

            // intersect the inline portion
            {
                var oldV = _bits0;
                var newV = oldV & other._bits0;
                if (newV != oldV)
                {
                    _bits0 = newV;
                    anyChanged = true;
                }
            }
            // intersect up to their common length.
            for (int i = 0; i < otherLength; i++)
            {
                var oldV = thisBits[i];
                var newV = oldV & other._bits[i];
                if (newV != oldV)
                {
                    thisBits[i] = newV;
                    anyChanged = true;
                }
            }

            // treat the other bit array as being extended with zeroes
            for (int i = otherLength; i < thisLength; i++)
            {
                if (thisBits[i] != 0)
                {
                    thisBits[i] = 0;
                    anyChanged = true;
                }
            }

            Check();
            return anyChanged;
        }

        /// <summary>
        /// Modify this bit vector by '|'ing each element with the other bit vector.
        /// </summary>
        /// <returns>
        /// True if any bits were set as a result of the union.
        /// </returns>
        public bool UnionWith(in ExtensibleBitVector other)
        {
            bool anyChanged = false;

            if (other._capacity > _capacity)
                EnsureCapacity(other._capacity);

            Word oldbits = _bits0;
            _bits0 |= other._bits0;

            if (oldbits != _bits0)
                anyChanged = true;

            for (int i = 0; i < other._bits.Length; i++)
            {
                oldbits = _bits[i];
                _bits[i] |= other._bits[i];

                if (_bits[i] != oldbits)
                    anyChanged = true;
            }

            Check();

            return anyChanged;
        }

        /// <summary>
        /// Modify this bit vector by '&'ing each negated element with the other bit vector.
        /// </summary>
        /// <returns>
        /// True if any bits were set as a result of the operation.
        /// </returns>
        public bool UnsetWith(in ExtensibleBitVector other)
        {
            bool anyChanged = false;

            if (other._capacity > _capacity)
                EnsureCapacity(other._capacity);

            Word oldbits = _bits0;
            _bits0 &= ~other._bits0;

            if (oldbits != _bits0)
                anyChanged = true;

            for (int i = 0; i < other._bits.Length; i++)
            {
                oldbits = _bits[i];
                _bits[i] &= ~other._bits[i];

                if (_bits[i] != oldbits)
                    anyChanged = true;
            }

            Check();

            return anyChanged;
        }

        public bool IncludesAll(ExtensibleBitVector bits)
        {
            foreach (var index in bits.TrueBits())
            {
                if (index >= _capacity) return false;
                int i = (index >> Log2BitsPerWord) - 1;
                var word = (i < 0) ? _bits0 : _bits[i];
                if (!IsTrue(word, index)) return false;
            }
            return true;
        }

        public bool this[int index]
        {
            get
            {
                if (index >= _capacity)
                    return false;
                int i = (index >> Log2BitsPerWord) - 1;
                var word = (i < 0) ? _bits0 : _bits[i];

                return IsTrue(word, index);
            }

            set
            {
                if (index >= _capacity)
                    EnsureCapacity(index + 1);
                int i = (index >> Log2BitsPerWord) - 1;
                int b = index & (BitsPerWord - 1);
                Word mask = ((Word)1) << b;
                if (i < 0)
                {
                    if (value)
                        _bits0 |= mask;
                    else
                        _bits0 &= ~mask;
                }
                else
                {
                    if (value)
                        _bits[i] |= mask;
                    else
                        _bits[i] &= ~mask;
                }
            }
        }

        public void Clear()
        {
            _bits0 = 0;
            if (_bits != null) Array.Clear(_bits, 0, _bits.Length);
        }

        public static bool IsTrue(Word word, int index)
        {
            int b = index & (BitsPerWord - 1);
            Word mask = ((Word)1) << b;
            return (word & mask) != 0;
        }

        public static int WordsRequired(int capacity)
        {
            if (capacity <= 0) return 0;
            return WordsForCapacity(capacity) + 1;
        }

        internal string GetDebuggerDisplay()
        {
            var value = new char[_capacity];
            for (int i = 0; i < _capacity; i++)
            {
                value[_capacity - i - 1] = this[i] ? '1' : '0';
            }
            return new string(value);
        }
    }
}
