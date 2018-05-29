using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Project.ExtensionMethods
{
    class ExtensionsDemo
    {
        public static void Demo()
        {
            string str = "this is a list of words separated by spaces, and I want to shorten it to 5 words";
            Console.WriteLine(str);
            var shortened = str.Shorten(5); //This method is located in the StringExtensions static class. 
            Console.WriteLine(str);
        }


    }
}
