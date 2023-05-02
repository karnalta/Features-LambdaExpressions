using System;

namespace Features_LambdaExpressions
{
    /// <summary>
    /// Action<> and Func<> delegate.
    /// </summary>
    internal class ActionAndFuncSample
    {
        public void Test()
        {
            // Action delegate (no return type) declared with lambda expression
            Action<string, int> localAction = (name, value) => { Console.WriteLine($"Action<string, int> called with string parameter : '{name}' and int parameter : '{value}'"); };
            localAction("local action", 999);
            Console.WriteLine();

            // Get a Action from a method
            var methodAction = CreateAction(5);
            methodAction(10);
            Console.WriteLine();

            // Func delegate (with return type)
            Func<string, int, int> localFunc = (name, value) =>
            {
                Console.WriteLine($"Func<string, int, int> called with string parameter : '{name}' and int parameter : '{value}'");

                return 999;
            };
            Console.WriteLine($"And returned {localFunc("local func", 5)}");
            Console.WriteLine();

            // Pass a Func delegate to a method by using a lambda expression for Func body
            ExecuteFunc((value) => { return value * 10; });
        }

        /// <summary>
        /// Creates an Action<> delegate.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private Action<int> CreateAction(int value)
        {
            Action<int> action = (localValue) => { Console.WriteLine($"Executing method action with method value of {value} and local value of {localValue}."); };

            return action;
        }

        /// <summary>
        /// Executes a Func<> delegate.
        /// </summary>
        /// <param name="func">The function.</param>
        private void ExecuteFunc(Func<int, int> func)
        {
            Console.WriteLine($"Executing a Func<int, int> delagate received as parameter with value '5'.");
            Console.WriteLine($"Return value = {func(5)}");
        }
    }
}
