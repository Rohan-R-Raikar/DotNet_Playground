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

            int Number = Convert.ToInt32(Console.ReadLine());

            Brute_Force_Approach.CheckPrime(Number);
        }
    }
}