namespace Check_for_Prime_Number
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
             * What is a Prime Number
             * A number which is exactly 2 factors 1 & itself.
             */
            Console.WriteLine("Enter a Numer to Check Prime Number");
            int Number = Convert.ToInt32(Console.ReadLine());

            Brute_Force_Approach.CheckPrime(Number);
            Half_Loop_Approach.CheckPrime(Number);
            Square_Root_Approach.CheckPrime(Number);
            Best_Single_Check_i_into_i.CheckPrime(Number);
            BEST_Prime_Check_No_Counter_Needed.CheckPrime(Number);
            Fastest_for_Many_Numbers__Sieve_of_Eratosthenes.CheckPrime();
        }
    }
}