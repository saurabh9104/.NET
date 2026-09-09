using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q20
    {
        // convert string to upper case.
        public static void convertToUpperCase()
        {
            //string str = "Hello World";
            //string upperStr = str.ToUpper();
            //Console.WriteLine("Uppercase: {0}", upperStr);
            string str = "Hello World";
            char[] arr = str.ToCharArray();
            string upperStr = "";
            foreach (char c in arr)
            {
                if (c >= 'a' && c <= 'z')
                {
                    char upperChar = ((char)(c - 32));
                    upperStr += upperChar;
                }
                else
                {
                    Console.Write(c);
                    upperStr += c;
                }
            }
            Console.WriteLine("Uppercase: {0}", upperStr);


        }

    }
}
