using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_for_Prime_Number
{
    // BEST Prime Check (No Counter Needed)
    public static class BEST_Prime_Check_No_Counter_Needed
    {
        public static void CheckPrime(int Number)
        {
            if (Number <= 0)
            {
                Console.WriteLine("Not Prime");
                return;
            }

            bool isPrime = true;

            for (int i = 0; i*i <= Number; i++)
            {
                if (Number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not Prime");
        }
    }
}
