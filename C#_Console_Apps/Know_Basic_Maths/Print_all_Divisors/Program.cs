namespace Print_all_Divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                if(num % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}