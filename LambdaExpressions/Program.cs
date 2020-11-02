using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action, corresponding to "void action()" 
            Action action1 = () => { Console.WriteLine("Hallo Lambda!"); };
            action1();


            // Action<int>, corresponding to "void action(int n)"
            Action<int> action2 = (n) => { Console.WriteLine("action2 called with number: " + n); };
            action2(3);


            // Func<int>, corresponding to "int func1()"
            Func<int> func1 = () => 7;  

            Console.WriteLine("func1(): " + func1());


            // Func<bool, int>, corresponding to "int func2(bool b)
            Func<bool, int> func2 = (b) =>  b ? 1 : 0; ;

            Console.WriteLine("func2(true): " + func2(true));


            // Func<int, int, int>, corresponding to "int func3(int a, int b)
            Func<int, int, int> func3 = (a, b) => a + b;

            Console.WriteLine("func3(5, 7): " + func3(5, 7));


            // Func<int, string> with a body
            Func<int, string> func4 = (a) =>
            {
                string s = "";

                for (int n=0; n < a; n++)
                {
                    s += "|";
                }

                return s;
            };

            Console.WriteLine("func4(4): " + func4(4));
            Console.WriteLine("func4(10): " + func4(10));


            // Higher order function that returns another function
            Func<int, Func<int, int>> higherOrderFunc1 = (n) => (m) => n + m;

            Console.WriteLine("higherOrderFunc1(3)(4): " + higherOrderFunc1(3)(4));


            // Higher order function that takes another function as input parameter
            Func<Func<int, int>, int, int> applyFunction = (function, n) => function(n);

            Console.WriteLine("applyFunction(n => n + 1, 1): " + applyFunction(n => n + 1, 1));

        }
    }
}
