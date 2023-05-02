using System;

namespace Features_LambdaExpressions
{
    /// <summary>
    /// Original .NET delegate.
    /// </summary>
    internal class DelegateSample
    {
        public delegate int MathOpDelegate(int x, int y);

        public void Test()
        {
            MathOpDelegate myDelegate = Addition;
            Console.WriteLine($"1 + 1 = {myDelegate(1, 1)}");
            Console.WriteLine();

            myDelegate = Multiplication;
            Console.WriteLine($"2 * 4 = { myDelegate(2, 4) }");
            Console.WriteLine();

            // Anonymous expression as a delegate method
            myDelegate = delegate (int x, int y)
            {
                Console.WriteLine("Anonymous method called.");
                return x / y; 
            };
            Console.WriteLine($"20 / 4 = { myDelegate(20, 4) }");
            Console.WriteLine();

            // Register multiple methods to a delegate
            myDelegate = Addition;
            myDelegate += Multiplication;

            Console.WriteLine($"Calling a delegate (5,2) with multiple registered methods, only return the last method result : {myDelegate(5, 2)}");
            Console.WriteLine();
        }

        /// <summary>
        /// Delegate body.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        private int Addition(int a, int b)
        {
            Console.WriteLine("Addition method called.");
            return a + b;
        }

        /// <summary>
        /// Delegate body.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        private int Multiplication(int a, int b)
        {
            Console.WriteLine("Multiplication method called.");
            return a * b;
        }
    }
}
