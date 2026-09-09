using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.StringManupulation
{
    public class Q18
    {
        // write a code for reverse the string .
        public static void reverseString() 
        { 
            string str = "Hello World! 1234 @#$%";
            char[] arr = str.ToCharArray();

            for(int i = 0, j = arr.Length - 1; i < arr.Length/2; i++, j--) {
                
                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            String ReversedString = new string(arr);
            Console.WriteLine("Reversed string: {0}", ReversedString);
        }
        public static void reverseEachword() 
        {
            string str = "Hello World! 1234 @#$%";
            string[] words = str.Split(' ');
            StringBuilder reversedString = new StringBuilder();
            foreach (string word in words)
            {
                char[] arr = word.ToCharArray();
                Array.Reverse(arr);
                reversedString.Append(new string(arr) + " ");
            }
            Console.WriteLine("Reversed each word: {0}", reversedString.ToString().Trim());
        }
    }
}
