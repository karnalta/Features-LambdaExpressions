using System;

namespace Features_LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = new Sample();
            sample.Test();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
