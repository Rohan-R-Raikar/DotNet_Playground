using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check_for_Prime_Number
{
    public static class Fastest_for_Many_Numbers__Sieve_of_Eratosthenes
    {
        public static void CheckPrime()
        {
            Console.WriteLine();
            Console.WriteLine("==========================Fastest_for_Many_Numbers__Sieve_of_Eratosthenes========================== START");

            int n = 100;

            bool[] prime = new bool[n + 1];

            for (int i = 2; i <= n; i++)
                prime[i] = true;

            for (int i = 2; i * i <= n; i++)
            {
                if (prime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        prime[j] = false;
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (prime[i])
                    Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("==========================Fastest_for_Many_Numbers__Sieve_of_Eratosthenes========================== END");
            Console.WriteLine();
        }
    }
}
