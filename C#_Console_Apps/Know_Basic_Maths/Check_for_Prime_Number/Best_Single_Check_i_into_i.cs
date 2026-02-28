using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Check_for_Prime_Number
{
    public static class Best_Single_Check_i_into_i
    {
        // i*i <= N Method (Best Single Check)
        public static void CheckPrime(int Number)
        {
            Console.WriteLine();
            Console.WriteLine("==========================Best_Single_Check_i_into_i========================== START");

            int count = 0;

            for (int i = 1; i * i <= Number; i++)
            {
                if (Number % i == 0)
                {
                    count++;

                    if (Number / i != i)
                        count++;
                }
            }

            if (count == 2)
                Console.WriteLine("Prime");
            else
                Console.WriteLine("Not Prime");

            Console.WriteLine("==========================Best_Single_Check_i_into_i========================== END");
            Console.WriteLine();
        }
    }
}
