namespace StarPattern9outof22
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = 5;
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - i; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("  ");
                }
                for (int j = 0; j < (rows * 2) - (2 * i + 1); j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}