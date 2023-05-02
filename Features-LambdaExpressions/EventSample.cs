using System;

namespace Features_LambdaExpressions
{
    /// <summary>
    /// .NET event.
    /// </summary>
    internal class EventSample
    {
        public delegate void EventDelegate(int value);
        public event EventDelegate MyEvent;

        public void Test()
        {
            // Declaring an handler to MyEvent;
            MyEvent += (int x) => { Console.WriteLine($"MyEvent has been fired with value {x}"); };

            // Triggering MyEvent
            MyEvent(5);
            MyEvent.Invoke(10);
            Console.WriteLine();
        }
    }
}
