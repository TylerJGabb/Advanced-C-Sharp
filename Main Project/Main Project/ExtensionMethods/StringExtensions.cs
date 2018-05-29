using System;
using System.Linq;

//Put in system namespace because thats where String exists
namespace System
{
    public static class StringExtensions
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            var list = str.Split(' ');
            var shorterList = list.Take(numberOfWords);
            var ret = string.Join(" ", shorterList);
            return ret + "...";
        }
    }
}