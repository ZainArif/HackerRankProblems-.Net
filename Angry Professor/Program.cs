using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angry_Professor
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] nk = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nk[0]);

                int k = Convert.ToInt32(nk[1]);

                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
                string result = angryProfessor(k, a);

                Console.WriteLine(result);
            }
        }

        static string angryProfessor(int k, int[] a)
        {
            string result;
            int onTime = 0;
            Array.Sort(a);

            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                    break;
                else
                    onTime++;
            }

            if (onTime >= k)
                result = "NO";
            else
                result = "YES";

            return result;
        }
    }
}
