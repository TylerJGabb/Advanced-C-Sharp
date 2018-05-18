using System;
using System.Security.Authentication.ExtendedProtection;
using System.Xml.Schema;

namespace Main_Project
{
    //where T : IComparable
    //where T : Product
    //where T : struct //(value type)
    //WHERE T : class //has to be a reference type
    //Where T : new() , T has to be an object with a default constructor
    public class Constraints<T> where T : IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public T Max(T a, T b) //using the generic type
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public TB Max<TB>(TB a, TB b)  where TB : IComparable //using a different type, generic method
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();//class needs a default constructor
        }
    }
}