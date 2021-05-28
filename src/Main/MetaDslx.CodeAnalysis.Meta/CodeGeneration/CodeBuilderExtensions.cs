using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MetaDslx.CodeGeneration
{
    public static class CodeBuilderExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this T item)
        {
            if (item == null) return new EmptyEnumerator<T>();
            else return new SingleEnumerator<T>(item);
        }

        private struct EmptyEnumerator<T> : IEnumerator<T>
        {
            public T Current => default;

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return false;
            }

            public void Reset()
            {
            }
        }

        private struct SingleEnumerator<T> : IEnumerator<T>
        {
            private T _item;
            private bool _finished;

            public SingleEnumerator(T item)
            {
                _item = item;
                _finished = false;
            }

            public T Current => _finished ? _item : default;

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                var result = !_finished;
                _finished = true;
                return result;
            }

            public void Reset()
            {
                _finished = false;
            }
        }
    }
}
