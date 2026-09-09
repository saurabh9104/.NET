using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class Q19
    {
        // check the string is palindrome or not.

        public void CheckPalindrome()
        {
            string str = "madam";
            string reversedStr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedStr += str[i];
            }
            if (str == reversedStr)
            {
                Console.WriteLine("{0} is a palindrome", str);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome", str);
            }
        }
    }
}
