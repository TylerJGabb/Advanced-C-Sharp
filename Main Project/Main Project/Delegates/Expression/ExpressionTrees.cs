using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Project.Delegates.Expression
{
    public static class ExpressionTrees
    {
        public delegate TResult GenericDelegate<T1, T2, TResult>(T1 arg1, T2 arg2);

        public static void Intro()
        {
            //You can use an Expression Tree to represent code in a tree-line format, where each node is an expression.
            //This means you can convert the expression into compiled code and run it. 

            //Here we have created a Func<> delegate which knows how to call executable code which takes two ints, and returns an int;
            //We assign a lambda function to it
            Func<int, int, int> function = (a, b) => a + b;

            //This is an example of using the generic delegate type we defined right above intro
            GenericDelegate<string, string, int> ptr = (str1, str2) => str2.Length + str1.Length;

            //The only difference between GenericDelegate and Func is that I made the type GenericDelegate type where System namespace provided the Func<> type;

            //We can point these delegates to other blocks of executable code
            int ComputeStuff(string str1, string str2)
            {
                return str2.Length + str1.Length;
            }

            int AddNumbersTogether(int a, int b)
            {
                return a + b;
            }

            ptr = ComputeStuff;
            function = AddNumbersTogether; //Their signatures must agree

            //LINQ provides syntax for translating code into a data structure called an expression tree. 
            Expression<Func<int, int, int>> expression = (a, b) => a + b;

            //note here that expression is not executable code, it is an expression
            /**
             * There are four main parts to an expression tree
             * 1) Body : The body of the expression
             * 2) Parameters : The parameters of the lambda expression or executable code which was passed
             * 3) NodeType : The ExpressionType for some node in the tree
             * 4) Type : The static type of the expression, in this case it is Func<int, int, int, int, int>
             */

            //We can write code to explore this architecture

            //Print parameters
            int i = 0;
            foreach (var expressionParameter in expression.Parameters)
            {
                Console.WriteLine($"Parameter {i} is {expressionParameter.Name}");
                i++;
            }

            //Explore the Body
            var body = expression.Body as BinaryExpression;
            var left = body.Left;
            var right = body.Right;
            Console.WriteLine($"Expression body: {expression.Body}");
            Console.WriteLine($"Left: {left}");
            Console.WriteLine($"Right: {right}");
            Console.WriteLine($"Node Type: {body.NodeType}");
            Console.WriteLine($"Return Type: {body.Type}");
            //We could feasibly recurse down to the lowest level but the POC is done


            //We can convert the expression tree back into code
            Func<int, int, int> executableCode = expression.Compile();
            Console.WriteLine($@"Compiling and Invoking(1,2) yields {executableCode.Invoke(1, 2)}");
        }


        public static string GetName<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression) e.Body;
            //member represents "obj.Prop"
            return member.Member.Name;
        }

        public static void PrintPropertyWithValue<T>(Expression<Func<T>> e)
        {
            var member = (MemberExpression) e.Body;
            var propertyName = member.Member.Name;
            Func<T> __delegate = e.Compile(); //turns the expression into a delegate, compiles the code in the tree
            Console.WriteLine($"{propertyName} = {__delegate.Invoke()}");
        }

        public static void Demo1()
        {
            string str = "Test";
            var x = GetName(() => str.Length);
        }

        public static void Demo2()
        {
            var obj = new
            {
                Name = "Tyler",
                Age = 26,
                WorkPlace = "Hexagon Mining"
            };

            PrintPropertyWithValue(() => obj.Name);
            PrintPropertyWithValue(() => obj.Name);
            PrintPropertyWithValue(() => obj.WorkPlace);
        }
    }
}
