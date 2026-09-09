using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q24
    {
        // remove duplicates from string.
        public static void removeDuplicates()
        {
            //string str = "hello world";
            //string uniqueStr = "";
            //char[] arr = str.ToCharArray();

            //foreach (char c in arr)
            //{
            //    if (!uniqueStr.Contains(c))
            //    {
            //        uniqueStr += c;xz
            //    }
            //}
            //Console.WriteLine(uniqueStr);

            string str = "hello world";
            string uniqueStr = "";
            char[] arr = str.ToCharArray();
            char[] arr2;

            foreach (char c in arr)
            {
                if (uniqueStr.Contains(c))
                {
                    continue;
                }
                else
                {
                    uniqueStr += c;
                }
            }
        }
    }
}
