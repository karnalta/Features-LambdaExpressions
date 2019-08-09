using System;
using System.Linq.Expressions;

namespace Features_LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Local action
            Action<string, int> localAction = (name, value) => { Console.WriteLine($"Executing {name} with value {value}."); };
            localAction("local action", 1);

            Console.WriteLine();

            // Action from a method
            var methodAction = CreateAction(2);
            methodAction(3);

            Console.WriteLine();

            // Func from a method
            Func<string, int, int> localFunc = (name, value) => 
            {
                Console.WriteLine($"Executing {name} with value {value}.");

                return 6;
            };
            Console.WriteLine($"And returned {localFunc("local func", 5)}");

            Console.WriteLine();

            // Func to a method
            ExecuteFunc((value) => { return value * 10; });

            Console.WriteLine();

            // Local expression
            Expression<Func<int, int, int>> localExp = (x, y) => x * y;
            Console.WriteLine($"Local expression to string => { localExp }");

            // Compiling and running the local expression
            Console.WriteLine($"Local expression result after compilation => { localExp.Compile()(5, 4) }");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Creates an action.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        static Action<int> CreateAction(int value)
        {
            Action<int> action = (localValue) => { Console.WriteLine($"Executing method action with method value {value} and local value {localValue}."); };

            return action;
        }

        /// <summary>
        /// Executes a function.
        /// </summary>
        /// <param name="func">The function.</param>
        static void ExecuteFunc(Func<int, int> func)
        {
            for (int i = 1; i <= 3; i++)
                Console.WriteLine($"Executing method func with iteration {i} and it returned { func(i) }.");
        }
    }
}
