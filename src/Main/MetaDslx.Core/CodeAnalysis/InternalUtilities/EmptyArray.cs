namespace Roslyn.Utilities
{
    public class EmptyArray<T>
    {
        public static readonly T[] Instance = new T[0];
    }
}