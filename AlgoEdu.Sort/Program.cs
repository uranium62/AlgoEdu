using System;
using NUnitLite;

namespace NUnitLite.Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new AutoRun().Execute(args);

            Console.ReadKey();
        }
    }
}