using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q17
    {
        // Count the number of vovels and consonants int string.

        public static void CountVowelsAndConsonants()
        {
            string str = "Hello World! 1234 @#$%";
            int vowelCount = 0;
            int consonantCount = 0;
            //foreach (char c in str)
            //{
            //    if (char.IsLetter(c))
            //    {
            //        char lowerChar = char.ToLower(c);
            //        if (lowerChar == 'a' || lowerChar == 'e' || lowerChar == 'i' || lowerChar == 'o' || lowerChar == 'u')
            //        {
            //            vowelCount++;
            //        }
            //        else
            //        {
            //            consonantCount++;
            //        }
            //    }
            //}
            foreach(char c in str)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
                {
                    // char lowerChar = char.ToLower(c);

                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }


            Console.WriteLine("Vowels: {0}", vowelCount);
            Console.WriteLine("Consonants: {0}", consonantCount);
        }



    }
}
