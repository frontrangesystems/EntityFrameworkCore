using System;
using System.Runtime.CompilerServices;

namespace MoviesApp.Helpers
{
    public static class ConsoleHelper
    {
        public static void WriteSpacer(string label = null)
        {
            Console.WriteLine();
            Console.WriteLine();
            var separator = new string('-', 40);
            Console.WriteLine(separator);
            if (!string.IsNullOrWhiteSpace(label))
            {
                Console.WriteLine(label);
                Console.WriteLine(separator);
            }
        }

        public static void WriteCaller([CallerMemberName] string name = null)
        {
            WriteSpacer(name);
        }
    }
}
