namespace Playground
{
    public static class ArrayCreator
    {
        public static T[] CreateArray<T>(int length, T item)
            where T : struct
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
                result[i] = item;

            return result;
        }

        public static T[] CreateArray<T>(int length)
            where T : class, new ()
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
                result[i] = new T();

            return result;
        }
    }
}
