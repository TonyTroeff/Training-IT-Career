using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace StaticVsNonStatic
{
    internal static class StaticBookGenerator
    {
        private static List<string> preGeneratedNames = new List<string>();

        // This static constructor is invoked if:
        // - A static member is accessed
        // - An instance of the type is created (this cannot be done for static types)
        static StaticBookGenerator()
        {
            for (int i = 0; i < 100; i++) preGeneratedNames.Add($"Name #{i + 1}");
        }

        public static Book GenerateBook()
        {
            Book b = new Book { Name = preGeneratedNames[15] };
            return b;
        }
    }
}
