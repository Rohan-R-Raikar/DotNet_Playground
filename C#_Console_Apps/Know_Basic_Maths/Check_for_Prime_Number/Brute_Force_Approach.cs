using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_for_Prime_Number
{
    // Brute Force Approach — O(N)
    public static class Brute_Force_Approach
    {
        public static void CheckPrime(int Number)
        {
            Console.WriteLine();
            Console.WriteLine("==========================Brute_Force_Approach========================== START");

            int count = 0;

            for (int i = 1; i <= Number; i++)
            {
                if (Number % i == 0)
                {
                    count++;
                }
            }

            if (count == 2)
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not Prime");

            Console.WriteLine("==========================Brute_Force_Approach========================== END");
            Console.WriteLine();
        }
    }
}
