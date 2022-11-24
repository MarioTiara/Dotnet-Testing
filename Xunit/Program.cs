using System;

namespace Dotnet_UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool val;
            string input;

            input = bool.TrueString;
            val = bool.Parse(input);
            Console.WriteLine("'{0}' parsed as {1}", input, val);
        }

    }
}
