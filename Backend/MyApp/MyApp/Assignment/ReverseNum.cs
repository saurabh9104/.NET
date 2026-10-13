using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Assignment
{
    public class ReverseNum
    {
        public static void reverseNumber()
        {
            int num = 12345;
            int reversedNum = 0;
            while (num > 0)
            {
                int digit = num % 10;
                reversedNum = (reversedNum * 10) + digit;
                num /= 10;
            }
            Console.WriteLine("Reversed Number: {0}", reversedNum);
        }
    }
}
