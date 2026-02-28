using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_for_Prime_Number
{
    // Half Loop Approach — O(N/2)
    public static class Half_Loop_Approach
    {
        public static void CheckPrime(int Number)
        {
            Console.WriteLine("START ==========================Half_Loop_Approach==========================");

            int count = 0;

            for (int i = 1; i <= Number / 2; i++)
            {
                if (Number % i == 0)
                {
                    count++;
                }
            }

            count++;

            if (count == 2)
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not Prime");

            Console.WriteLine("==========================Half_Loop_Approach========================== END");
        }
    }
}
