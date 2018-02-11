﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

namespace MetaDslx.Compiler.Utilities
{
    /// <summary>
    /// Represents a value type that can be assigned null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Optional<T>
    {
        public static Optional<T> None = new Optional<T>();
        public static Optional<T> Default = new Optional<T>(default(T));

        private readonly bool _hasValue;
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance to the specified value.
        /// </summary>
        /// <param name="value"></param>
        private Optional()
        {
            _hasValue = false;
            _value = default(T);
        }

        /// <summary>
        /// Initializes a new instance to the specified value.
        /// </summary>
        /// <param name="value"></param>
        public Optional(T value)
        {
            _hasValue = true;
            _value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the current object has a value.
        /// </summary>
        /// <returns></returns>
        public bool HasValue
        {
            get { return _hasValue; }
        }

        /// <summary>
        /// Gets the value of the current object.
        /// </summary>
        /// <returns></returns>
        public T Value
        {
            get { return _value; }
        }
    }
}