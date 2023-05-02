using System;

namespace Features_LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var delegateSample = new DelegateSample();
            delegateSample.Test();

            Console.WriteLine();

            var actionAndFuncSample = new ActionAndFuncSample();
            actionAndFuncSample.Test();

            Console.WriteLine();

            var expressionTreeSample = new ExpressionTreeSample();
            expressionTreeSample.Test();

            Console.WriteLine();

            var eventSample = new EventSample();
            eventSample.Test();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}
