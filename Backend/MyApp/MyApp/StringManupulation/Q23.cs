using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q23
    {
        // remove whitespace from string.
        public static void removeWhitespace()
        {
            //string str = "Hello World";
            //string noWhitespaceStr = str.Replace(" ", "");
            //Console.WriteLine("String without whitespace: {0}", noWhitespaceStr);

            string str = "hello world";
            string noWhitespaceStr = "";
            char[] arr = str.ToCharArray();

            foreach (char c in arr) {
                if (c == ' ') 
                {
                    continue;
                }
                else
                {
                    noWhitespaceStr += c;
                }
            }
            Console.WriteLine(noWhitespaceStr);


        }
    }
}
