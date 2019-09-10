using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Features_LambdaExpressions
{
    public class Sample
    {
        public delegate int MyDelegate(int x, int y);

        public void Test()
        {
            // Original .NET delegate
            var oldDelegate = new MyDelegate(Addition);
            Console.WriteLine($"Original delegate -> 5 + 4 = { oldDelegate(5, 4) }.");
            oldDelegate = Multiplication;
            Console.WriteLine($"Original delegate -> 5 * 4 = { oldDelegate(5, 4) }.");
            oldDelegate = delegate (int x, int y) { return x / y; };
            Console.WriteLine($"Original delegate -> 20 / 4 = { oldDelegate(20, 4) }.");

            Console.WriteLine();

            // Local action (Generic delegate without return type)
            Action<string, int> localAction = (name, value) => { Console.WriteLine($"Executing {name} with value {value}."); };
            localAction("local action", 1);

            Console.WriteLine();

            // Action from a method
            var methodAction = CreateAction(2);
            methodAction(3);

            Console.WriteLine();

            // Local Func (Generic delegate with return type)
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
        }

        /// <summary>
        /// Creates an action.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private Action<int> CreateAction(int value)
        {
            Action<int> action = (localValue) => { Console.WriteLine($"Executing method action with method value {value} and local value {localValue}."); };

            return action;
        }

        /// <summary>
        /// Executes a function.
        /// </summary>
        /// <param name="func">The function.</param>
        private void ExecuteFunc(Func<int, int> func)
        {
            for (int i = 1; i <= 3; i++)
                Console.WriteLine($"Executing method func with iteration {i} and it returned { func(i) }.");
        }

        /// <summary>
        /// Delegate body.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        private int Addition(int a, int b)
        {
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
            return a * b;
        }
    }
}
