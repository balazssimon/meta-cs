using MetaDslx.Compiler.Syntax.InternalSyntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Compiler.Utilities
{
    public static class EmptyCollections
    {
        public static readonly object[] ObjectArray = new object[0];
        public static readonly GreenNode[] GreenArray = new GreenNode[0];

        public static IEnumerator EmptyEnumerator() => EmptyCollections.Empty.EmptyEnumerator.Instance;
        public static IEnumerator<T> EmptyEnumerator<T>() => EmptyCollections.Empty.EmptyEnumerator<T>.Instance;

        private static class Empty
        {
            public class EmptyEnumerator : IEnumerator
            {
                public static readonly IEnumerator Instance = new EmptyEnumerator();

                protected EmptyEnumerator()
                {
                }

                public object Current
                {
                    get
                    {
                        throw new InvalidOperationException();
                    }
                }

                public bool MoveNext()
                {
                    return false;
                }

                public void Reset()
                {
                    throw new InvalidOperationException();
                }
            }

            public class EmptyEnumerator<T> : EmptyEnumerator, IEnumerator<T>
            {
                public static new readonly IEnumerator<T> Instance = new EmptyEnumerator<T>();

                protected EmptyEnumerator()
                {
                }

                public new T Current
                {
                    get
                    {
                        throw new InvalidOperationException();
                    }
                }

                public void Dispose()
                {
                }
            }
        }
    }
}
