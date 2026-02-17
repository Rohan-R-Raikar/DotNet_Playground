namespace StarPattern3outof22
{
    class Program
    {
        static void Main(String[] args)
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}