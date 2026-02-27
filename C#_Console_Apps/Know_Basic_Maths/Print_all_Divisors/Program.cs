namespace Print_all_Divisors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());

            // Call the original method
            Console.WriteLine("Original method:");
            DivisorHelper.PrintDivisors(num);

            // Call the optimized method
            Console.WriteLine("\nOptimized method using List and square root:");
            DivisorHelperOptimized.PrintDivisors(num);
        }
    }
}