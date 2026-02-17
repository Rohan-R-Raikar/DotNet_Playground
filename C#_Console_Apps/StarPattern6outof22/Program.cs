namespace StarPattern6outof22
{
    class Program
    {
        static void Main(String[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < (5 - i); j++)
                {
                    Console.Write(j+1);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}