using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.Delegates.LambdaExpressions
{
    class LambdaDemo
    {
        //There are two primary types of lambda functions

        //Func and Action

        //Func is used when a value is expected in return, Action is used when no return value is expected

        //The generic form looks like this
        //args => expression

        public static void BeginnerDemo()
        {
            Func<int,int> square = number => number * number;
            Action<string> writeConsole = str => Console.WriteLine(str);
            Func<int, int, int> mult = (a, b) => a * b;

            writeConsole(square(5).ToString());
            writeConsole(mult(10, 2).ToString());
        }
    }
}
