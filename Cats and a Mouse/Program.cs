using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cats_and_a_Mouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of queries : ");
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] xyz = Console.ReadLine().Split(' ');

                int x = Convert.ToInt32(xyz[0]);

                int y = Convert.ToInt32(xyz[1]);

                int z = Convert.ToInt32(xyz[2]);

                string result = catAndMouse(x, y, z);

                Console.WriteLine(result);

            }

            Console.ReadLine();

        }

        static string catAndMouse(int x, int y, int z)
        {
            string result;
            int x_dis = Math.Abs(x - z);
            int y_dis = Math.Abs(y - z);
            if (x_dis == y_dis)
                result = "Mouse C";
            else if (x_dis < y_dis)
                result = "Cat A";
            else
                result = "Cat B";

            return result;
        }
    }
}
