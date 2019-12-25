using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Max_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 5 numbers : ");
            int[] arr = new int[5];
            for (int x = 0; x < 5; x++)
                arr[x] = int.Parse(Console.ReadLine());
            miniMaxSum(arr);
        }

        static void miniMaxSum(int[] arr)
        {
            Array.Sort(arr);
            Int64 min = 0, max = 0;
            for (int i = 0; i < 4; i++)
                min += arr[i];

            for (int i = 1; i <= 4; i++)
                max += arr[i];

            Console.WriteLine("{0} {1}", min, max);
            Console.ReadLine();
        }
    }
}
