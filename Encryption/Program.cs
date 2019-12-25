using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string : ");
            string s = Console.ReadLine();
            string result = encryption(s);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        static string encryption(string s)
        {
            string str = s;
            StringBuilder sb = new StringBuilder();
            int length = s.Length;
            double sqrt_length = Math.Sqrt(length);
            int rows = Convert.ToInt32(Math.Floor(sqrt_length));
            int cols = Convert.ToInt32(Math.Ceiling(sqrt_length));
            int check = rows * cols;
            string[] strArray = new string[rows];
            int start = 0, end = cols;

            if (check > length)
                str = str.PadRight(check);

            if (check < length)
            {
                rows++;
                check = rows * cols;
                str = str.PadRight(check);
                strArray = new string[rows];
            }

            for (int i = 0; i < rows; i++)
            {
                strArray[i] = str.Substring(start, end);
                start += cols;
            }

            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    if (!strArray[k][j].Equals(' '))
                        sb.Append(strArray[k][j]);
                }

                sb.Append(" ");
            }

            return Convert.ToString(sb);
        }
    }
}