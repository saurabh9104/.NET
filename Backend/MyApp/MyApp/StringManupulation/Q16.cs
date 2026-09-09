using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q16
    {
        // Write a C# program to Count the number of characters, digits, spaces, special characters in a string.
        
        public static void CountCharacters()
        {
            string str = "Hello World! 1234 @#$%";
            int charCount = 0;
            int digitCount = 0;
            int spaceCount = 0;
            int specialCount = 0;

            //foreach (char c in str)
            //{
            //    if (char.IsLetter(c))
            //        charCount++;
            //    else if (char.IsDigit(c))
            //        digitCount++;
            //    else if (char.IsWhiteSpace(c))
            //        spaceCount++;
            //    else
            //        specialCount++;
            //}

            //Console.WriteLine("Characters: {0}", charCount);
            //Console.WriteLine("Digits: {0}", digitCount);
            //Console.WriteLine("Spaces: {0}", spaceCount);
            //Console.WriteLine("Special Characters: {0}", specialCount);

            // Is letters.
            if (str == null)
            {
                Console.WriteLine("String is null");
            }
            else if (str == "")
            {
                Console.WriteLine("String is empty");
            }
            else if (str.Length == 0)
            {
                Console.WriteLine("String is empty");
            }
            else if (str.Length > 0)
            {
                Console.WriteLine("String is not empty");
                foreach (char c in str)
                {
                    if(c>='A' && c <= 'Z' || c >= 'a' && c <= 'z')
                    {
                        charCount++; 
                    }
                    else if (c >= '0' && c <= '9')
                    {
                        digitCount++;
                    }
                    else if (c == ' ')
                    {
                        spaceCount++;
                    }
                    else
                    {
                        specialCount++;
                    }
                }

            }
            Console.WriteLine("Characters: {0}", charCount);
            Console.WriteLine("Digits: {0}", digitCount);
            Console.WriteLine("Spaces: {0}", spaceCount);
            Console.WriteLine("Special Characters: {0}", specialCount);

        }



    }
}
