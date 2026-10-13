using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Assignment
{
    public class position_number
    {
        // k th largest of a number in an array

        public static void kthPosition()
        {
            int[] arr = { 5, 2, 9, 1, 5, 6 };
            int k = 3;
            Array.Sort(arr);
            Array.Reverse(arr);
            if (k > 0 && k <= arr.Length)
            {
                Console.WriteLine("{0}th largest number is: {1}", k, arr[k - 1]);
            }
            else
            {
                Console.WriteLine("Invalid value of k");
            }
            arr.Sort(arr)

        }
    }
}
