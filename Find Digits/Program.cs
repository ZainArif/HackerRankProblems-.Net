using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of test cases : ");
            int t = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= t; i++)
            {
                Console.WriteLine("Enter number for {0} test case : ", i);
                int n = Convert.ToInt32(Console.ReadLine());
                int result = findDigits(n);
                Console.WriteLine(result);
                Console.ReadLine();
            }
        }

        static int findDigits(int n)
        {
            String num = Convert.ToString(n);
            int length = num.Length;
            int no = n;
            int count = 0;
            int d = 0;
            for(int j = 1; j <= length; j++)
            {
                d = no % 10;
                if (d != 0)
                {
                    if ((n % d) == 0)
                        count++;
                }
                no /= 10;
            }
            return count;
        }
    }
}
