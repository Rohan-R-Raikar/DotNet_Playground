namespace Print_all_Divisors
{
    public static class DivisorHelperOptimized
    {
        public static void PrintDivisors(int num)
        {
            List<int> divisors = new List<int>();

            int sqrt = (int)Math.Sqrt(num);

            for(int i = 1; i <= sqrt; i++)
            {
                if(num % i == 0)
                {
                    divisors.Add(i);

                    if(i != num / i)
                        divisors.Add(num/i);
                }
            }
            divisors.Sort();

            Console.WriteLine($"Divisors of {num} are:");
            foreach (int d in divisors)
            {
                Console.WriteLine(d);
            }
        }
    }
}
