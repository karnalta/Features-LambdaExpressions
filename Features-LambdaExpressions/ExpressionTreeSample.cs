using System;
using System.Linq.Expressions;

namespace Features_LambdaExpressions
{
    internal class ExpressionTreeSample
    {
        public void Test()
        {
            // Local expression
            Expression<Func<int, int, int>> localExp = (x, y) => x * y;
            Console.WriteLine($"Local expression to string => {localExp}");

            // Compiling and running the local expression
            Console.WriteLine($"Local expression result after compilation => {localExp.Compile()(5, 4)}");
        }
    }
}
