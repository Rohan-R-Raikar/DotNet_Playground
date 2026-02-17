namespace StarPattern5outof22
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 5; j-i > 0; j--)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();

            }
            Console.ReadKey();
        }
    }
}