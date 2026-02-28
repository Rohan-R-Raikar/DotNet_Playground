using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_for_Prime_Number
{
    public static class Square_Root_Approach
    {
        // √N Method (Your First Code) — O(√N)
        public static void CheckPrime(int Number)
        {
            Console.WriteLine();
            Console.WriteLine("==========================Square_Root_Approach========================== START");

            int counter = 0;

            int sqrt = (int)Math.Sqrt(Number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (Number % i == 0)
                {
                    counter++;

                    if (Number / i != i)
                        counter++;
                }
            }

            if (counter == 2)
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not Prime");

            Console.WriteLine("==========================Square_Root_Approach========================== END");
            Console.WriteLine();
        }
    }
}
