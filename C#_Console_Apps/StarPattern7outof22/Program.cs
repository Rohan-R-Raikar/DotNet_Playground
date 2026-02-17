namespace StarPattern7outof22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < n - i; j++)
                {
                    Console.Write("  ");
                }
                for(int j = 0; j < 2*i + 1; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}